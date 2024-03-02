using Application.Dtos;
using Application.Services.CountProductByPrice;
using Application.Services.CountProductByPrice.Interfaces;
using Application.Services.Discounts;
using Application.Services.Discounts.Interfaces;
using Application.Services.Entities.Interfaces;
using Application.Services.Entities.Products.Interfaces.FashionInterfaces;
using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using Application.Services.GetMatchingProducts.Fashion;
using Application.Services.GetMatchingProducts.Technology;
using Application.Services.PriceIsHigherThan;
using Application.Services.PriceIsHigherThan.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers;

public class ProductsController(ICountProductsByPriceService countProductsByPriceService, IPriceIsHigherThanService priceIsHigherThanService, ICalculateDiscountService calculateDiscountService, IProductDtoService productDtoService, IReviewDtoService reviewDtoService, ISmartphoneDtoService smartphoneDtoService, IGameDtoService gameDtoService, IShoesDtoService shoesDtoService, ITshirtDtoService tshirtDtoService) : Controller
{

    private readonly ICountProductsByPriceService _countProductsByPriceService = countProductsByPriceService;
    private readonly IPriceIsHigherThanService _priceIsHigherThanService = priceIsHigherThanService;
    private readonly ICalculateDiscountService _calculateDiscountService = calculateDiscountService;
    private readonly IProductDtoService _productDtoService = productDtoService;
    private readonly IReviewDtoService _reviewDtoService = reviewDtoService;
    private readonly ISmartphoneDtoService _smartphoneDtoService = smartphoneDtoService;
    private readonly IGameDtoService _gameDtoService = gameDtoService;
    private readonly IShoesDtoService _shoesDtoService = shoesDtoService;
    private readonly ITshirtDtoService _tshirtDtoService = tshirtDtoService;
    public IEnumerable<ProductDto> _productsDto = new List<ProductDto>();
    private string _currentCategory = string.Empty;

    public async Task<IActionResult> IndexCategory(string categoryStr)
    {
        _ = await _productDtoService.GetProductsDtoAsync();
        IEnumerable<ProductDto> products;
        if (string.IsNullOrEmpty(categoryStr))
        {
            products = await _productDtoService.GetProductsDtoAsync();
        }
        else
        {
            var productsForCategory = await _productDtoService.GetProductsDtoByCategoriesAsync(categoryStr);

            if (!productsForCategory.Any())
            {
                return RedirectToAction("IndexCategory");
            }

            products = productsForCategory;
        }

        var productVw = new ProductViewModel()
        {
            ProductsDto = products,
            CurrentCategory = categoryStr
        };

        return View(productVw);

    }
    //In construction, nothing is finished yet
    public async Task<IActionResult> Index(string categoryStr, string brand, int page = 1, int pageSize = 9, string keyword = "", string minPrice = null, string maxPrice = null, bool? isDailyOffer = null, bool? isBestSeller = null, bool? isPriceHigh = null, bool? isPriceLow = null, bool? showAvailableOnly = null, bool? hasReviews = null)
    {
        var products = await _productDtoService.GetProductsDtoAsync();

        if (string.IsNullOrEmpty(categoryStr))
        {
            products = await _productDtoService.GetProductsDtoAsync();
        }
        else
        {
            var productsForCategory = await _productDtoService.GetProductsDtoByCategoriesAsync(categoryStr);

            if (!productsForCategory.Any())
            {
                return RedirectToAction("Index");
            }

            products = productsForCategory;
        }

        if (!string.IsNullOrEmpty(brand))
        {
            products = products.Where(p => p.ProductSpecificationsObjectValue.ProductBrand.Contains(brand));
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            var filteredProductsByKeyword = await _productDtoService.GetSearchProductDtoAsync(keyword);

            if (!filteredProductsByKeyword.Any())
            {
                return RedirectToAction("Index");
            }

            products = filteredProductsByKeyword;
        }


        if (!string.IsNullOrEmpty(minPrice))
        {
            if (decimal.TryParse(minPrice, out decimal parsedMinPrice))
            {
                products = products.Where(p => p.ProductPriceObjectValue.Price >= parsedMinPrice);
            }
        }

        if (!string.IsNullOrEmpty(maxPrice))
        {
            if (decimal.TryParse(maxPrice, out decimal parsedMaxPrice))
            {
                products = products.Where(p => p.ProductPriceObjectValue.Price <= parsedMaxPrice);
            }
        }


        if (isDailyOffer.HasValue)
        {
            products = products.Where(p => p.ProductFlagsObjectValue.IsDailyOffer == isDailyOffer);
        }


        if (isBestSeller.HasValue)
        {
            products = products.Where(p => p.ProductFlagsObjectValue.IsBestSeller == isBestSeller);
        }


        if (isPriceHigh.HasValue && isPriceHigh == true)
        {
            products = products.OrderByDescending(p => p.ProductPriceObjectValue.Price);
        }

        if (isPriceLow.HasValue && isPriceLow == true)
        {
            products = products.OrderBy(p => p.ProductPriceObjectValue.Price);
        }

        if (showAvailableOnly.HasValue && showAvailableOnly == true)
        {
            products = products.Where(p => p.Stock > 0);
        }

        if (hasReviews.HasValue && hasReviews == true)
        {
            products = products.Where(p => p.Reviews.Count != 0);
        }
        int totalProducts = products.Count();
        int totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
        var paginatedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.TotalPages = totalPages;
        ViewBag.CurrentPage = page;
        ViewBag.Keyword = keyword;

        var productVw = new ProductViewModel()
        {
            ProductsDto = paginatedProducts,
            CurrentCategory = categoryStr,
            CurrentBrand = brand
        };

        return View(productVw);
    }
    public IActionResult ClearFilter()
    {
        return RedirectToAction("Index");
    }

    //In construction, nothing is finished yet
    [AllowAnonymous]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var getIdProductDtoAsync = await _productDtoService.GetByIdAsync(id);
        if (getIdProductDtoAsync == null) return NotFound();

        var getProductsDto = await _productDtoService.GetProductsDtoAsync();
        var getSmartphonesDto = await _smartphoneDtoService.GetProductsDtoAsync();
        var getGamesDto = await _gameDtoService.GetProductsDtoAsync();
        var getShoesDto = await _shoesDtoService.GetProductsDtoAsync();
        var getTshirtsDto = await _tshirtDtoService.GetProductsDtoAsync();
        var getReviewsDto = await _reviewDtoService.GetReviewsDtoAsync();
        var discountPercentage = _calculateDiscountService.DiscountPercentage(getIdProductDtoAsync.ProductPriceObjectValue);
        var inTwelveInstallmentWithoutInterest = _calculateDiscountService.InTwelveInstallmentWithoutInterest(getIdProductDtoAsync.ProductPriceObjectValue);
        var inThreeInstallmentWithInterest = _calculateDiscountService.InThreeInstallmentWithInterest(getIdProductDtoAsync.ProductPriceObjectValue);
        var inSixInstallmentWithoutInterest = _calculateDiscountService.InSixInstallmentWithoutInterest(getIdProductDtoAsync.ProductPriceObjectValue);
        var priceIsHigherThanTwoThousand = await _countProductsByPriceService.CountingProductsAbovePriceAsync(2000);
        var priceIsBetweenTwoHundredAndAThousand = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(200, 1000);
        var priceIsLowerThanOneHundred = await _countProductsByPriceService.CountingProductsBelowPriceAsync(100);


        var productVw = new ProductViewModel()
        {
            ProductDto = getIdProductDtoAsync,
            ProductsDto = getProductsDto,
            SmartphonesDto = getSmartphonesDto,
            GamesDto = getGamesDto,
            ShoesDto = getShoesDto,
            TshirtsDto = getTshirtsDto,
            ReviewsDto = getReviewsDto,
            CalculateDiscountValuable = new CalculateDiscountValuable
            {
                DiscountPercentage = discountPercentage,
                InTwelveInstallmentWithoutInterest = inTwelveInstallmentWithoutInterest,
                InSixInstallmentWithoutInterest = inSixInstallmentWithoutInterest,
                InThreeInstallmentWithInterest = inThreeInstallmentWithInterest,
            },
            CountProductByPriceValuable = new CountProductByPriceValuable
            {
                CountPriceIsHigherThanTwoThousand = priceIsHigherThanTwoThousand,
                CountPriceIsBetweenTwoHundredAndAThousand = priceIsBetweenTwoHundredAndAThousand,
                CountPriceIsLowerThanOneHundred = priceIsLowerThanOneHundred
            },
            GetMatchingProductsDto = new GetMatchingProductsDtoTechnology
            {
                ProductDto = getIdProductDtoAsync,
                SmartphonesDto = getSmartphonesDto,
                GamesDto = getGamesDto,
            },
            GetMatchingProductsDtoFashion = new GetMatchingProductsDtoFashion
            {
                ProductDto = getIdProductDtoAsync,
                TshirtsDto = getTshirtsDto,
                ShoesDto = getShoesDto
            },
            PriceIsHigherThanServiceBooleans = new PriceIsHigherThanServiceBooleans
            {
                ProductDto = getIdProductDtoAsync
            }
        };

        return View(productVw);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Search(string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            _productsDto = await _productDtoService.GetProductsDtoAsync();
        }
        else
        {
            _productsDto = await _productDtoService.GetSearchProductDtoAsync(search);
            if (!_productsDto.Any())
            {
                return RedirectToAction("ProductNotFound");
            }
        }

        var productVw = new ProductViewModel()
        {
            ProductsDto = _productsDto
        };
        return View("Index", productVw);
    }


    [AllowAnonymous]
    public IActionResult ProductNotFound()
    {
        return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> PriceIsHigherThanTwoThousand()
    {
        var filteredProducts = await _priceIsHigherThanService.GetProductsAbovePriceAsync(2000);
        var productVm = new ProductViewModel()
        {
            ProductsDto = filteredProducts.ToList()
        };
        return View(productVm);
    }

    [AllowAnonymous]
    public async Task<IActionResult> PriceIsBetweenTwoHundredAndAThousand()
    {
        var filteredProducts = await _priceIsHigherThanService.GetProductsAboveOrBelowPriceAsync(200, 1000);
        var productVm = new ProductViewModel()
        {
            ProductsDto = filteredProducts.ToList()
        };
        return View(productVm);
    }

    [AllowAnonymous]
    public async Task<IActionResult> PriceIsLowerThanOneHundred()
    {
        var filteredProducts = await _priceIsHigherThanService.GetProductsBelowPriceAsync(100);
        var productVm = new ProductViewModel()
        {
            ProductsDto = filteredProducts.ToList()
        };
        return View(productVm);
    }
}
