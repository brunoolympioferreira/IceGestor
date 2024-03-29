﻿using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Models.ViewModels.Product.Category;

namespace IceGestor.Application.Services.Product.Category;
public interface ICategoryService
{
    Task<BaseResult<int>> Create(CategoryInputModel model);
    Task Update(int id, CategoryInputModel model);
    Task<BaseResult> Delete(int id);
    Task<BaseResult<List<CategoryViewModel>>> GetAll();
    Task<BaseResult<CategoryViewModel>> GetById(int id);
}
