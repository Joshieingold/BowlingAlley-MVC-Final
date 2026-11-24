using System.ComponentModel.DataAnnotations;

public enum Division
{
    [Display(Name = "Men's")]
    Mens = 1,

    [Display(Name = "Women's")]
    Womens = 2,

    [Display(Name = "Mixed")]
    Mixed = 3,

    [Display(Name = "Youth")]
    Youth = 4,

    [Display(Name = "Senior")]
    Senior = 5,
}
