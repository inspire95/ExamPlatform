using ExamPlatform.Service.Interfaces;
using ExamPlatform.Service.Services;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.CategoryType.Request;
using ExamPlatform.ViewModels.CategoryType.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CategoryTypes")]
    public class CategoryTypesController : ControllerBase
    {
        private readonly ICategoryTypeService _categoryTypeService;
        public CategoryTypesController(CategoryTypeService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
        }

        [Route("GetCategoryTypes")]
        [HttpGet]
        public BaseResponse<VMGetCategoryTypeListResponse> GetAll(VMGetCategoryTypeListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetCategoryTypeListResponse>.SetError("Request body is empty");
            }
            
            try
            {
                var result = _categoryTypeService.GetAll(vmRequest);
                var responseObject = VMCategoryTypeItemList.ToResponse(result);
                var response = BaseResponse<VMGetCategoryTypeListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetCategoryTypeListResponse>.SetError(exc);
            }
        }

        [Route("GetCategoryTypeDetails")]
        [HttpGet]
        public BaseResponse<VMCategoryTypeDetailsResponse> Get(VMGetCategoryTypeDetailsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMCategoryTypeDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _categoryTypeService.Get(vmRequest);
                var responseObject = VMCategoryTypeItemList.ToResponse(result);
                var response = BaseResponse<VMCategoryTypeDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMCategoryTypeDetailsResponse>.SetError(exc);
            }
        }

        [Route("CreateCategoryType")]
        [HttpPost]
        public BaseResponse<VMCategoryTypeDetailsResponse> Create([FromBody]VMCreateCategoryTypeRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMCategoryTypeDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _categoryTypeService.Create(vmRequest);
                var responseObject = VMCategoryTypeItemList.ToResponse(result);
                var response = BaseResponse<VMCategoryTypeDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMCategoryTypeDetailsResponse>.SetError(exc);
            }
        }

        [Route("UpdateCategoryType")]
        [HttpPut]
        public BaseResponse<VMCategoryTypeDetailsResponse> Update([FromBody]VMUpdateCategoryTypeRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMCategoryTypeDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _categoryTypeService.Update(vmRequest);
                var responseObject = VMCategoryTypeItemList.ToResponse(result);
                var response = BaseResponse<VMCategoryTypeDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMCategoryTypeDetailsResponse>.SetError(exc);
            }
        }

        [Route("DeleteCategoryType")]
        [HttpDelete]
        public BaseResponse<BooleanResponse> Remove(VMRemoveCategoryTypeRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }
            try
            {
                bool result = _categoryTypeService.Remove(vmRequest);
                BooleanResponse responseObject = new BooleanResponse(result);
                var response = BaseResponse<BooleanResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<BooleanResponse>.SetError(exc);
            }
        }
    }
}
