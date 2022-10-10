﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public Assignment[] Suggestions;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Planner planner = new Planner();
        this.Suggestions = planner.Plan();
    }
}
