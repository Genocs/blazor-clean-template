﻿using Genocs.BlazorClean.Template.Shared.Constants.Permission;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.Delete;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.Import;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.Export;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetAll;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Genocs.BlazorClean.Template.Server.Controllers.v1.Catalog;

public class BrandsController : BaseApiController<BrandsController>
{
    /// <summary>
    /// Get All Brands
    /// </summary>
    /// <returns>Status 200 OK</returns>
    [Authorize(Policy = Permissions.Brands.View)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());
        return Ok(brands);
    }

    /// <summary>
    /// Get a Brand By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status 200 Ok</returns>
    [Authorize(Policy = Permissions.Brands.View)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var brand = await _mediator.Send(new GetBrandByIdQuery() { Id = id });
        return Ok(brand);
    }

    /// <summary>
    /// Create/Update a Brand
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [Authorize(Policy = Permissions.Brands.Create)]
    [HttpPost]
    public async Task<IActionResult> Post(AddEditBrandCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    /// <summary>
    /// Delete a Brand
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status 200 OK</returns>
    [Authorize(Policy = Permissions.Brands.Delete)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteBrandCommand { Id = id }));
    }

    /// <summary>
    /// Use this api to search a brands and export it into Excel
    /// </summary>
    /// <param name="searchString"></param>
    /// <returns></returns>
    [Authorize(Policy = Permissions.Brands.Export)]
    [HttpGet("export")]
    public async Task<IActionResult> Export(string searchString = "")
    {
        return Ok(await _mediator.Send(new ExportBrandsQuery(searchString)));
    }

    /// <summary>
    /// Import Brands from Excel
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [Authorize(Policy = Permissions.Brands.Import)]
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportBrandsCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}