using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test.Request
{
    [DataContract]
    public class VMGenerateTestRequest
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int Time { get; set; }

        [DataMember]
        public int OpenQuestion { get; set; }

        [DataMember]
        public int ClosedQuestion { get; set; }

        [DataMember]
        public int RequiredPercentage { get; set; }

        [DataMember]
        public int[] TestCategories { get; set; }
    }
}
