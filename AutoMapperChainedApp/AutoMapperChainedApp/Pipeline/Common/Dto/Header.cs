namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class Header
    {
        public string BusinessEntity { get; set; }
        public string ConversationId { get; set; }
        public string Direction { get; set; }
        public string DocInstanceCreateDt { get; set; }
        public string DocInstanceId { get; set; }
        public string FromPartyId { get; set; }
        public string IsFullyPopulated { get; set; }
        public string Method { get; set; }
        public string Noun { get; set; }
        public string OrigDocId { get; set; }
        public string PubSystemId { get; set; }
        public string Region { get; set; }
        public string ResponderProcessId { get; set; }
        public string ToPartyId { get; set; }
        public int UdmMajorRevId { get; set; }
        public int UdmMinorRevId { get; set; }
        public string Verb { get; set; }
        public string ExtraValue { get; set; }
    }
}
