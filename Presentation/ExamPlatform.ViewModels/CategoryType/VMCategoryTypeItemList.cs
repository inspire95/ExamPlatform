using ExamPlatform.ViewModels.CategoryType.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType
{
    [DataContract]
    public class VMCategoryTypeItemList
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int CategoryTypeId { get; set; }
        
        public static VMCategoryTypeDetailsResponse ToResponse(VMCategoryTypeDetails vmModel)
        {
            var vmResponse = new VMCategoryTypeDetailsResponse
            {
                CategoryType = vmModel
            };
            return vmResponse;
        }

        public static VMGetCategoryTypeListResponse ToResponse(List<VMCategoryTypeItemList> vmModel)
        {
            var vmResponse = new VMGetCategoryTypeListResponse
            {
                CategoryTypes = vmModel
            };
            return vmResponse;
        }
    }
}
