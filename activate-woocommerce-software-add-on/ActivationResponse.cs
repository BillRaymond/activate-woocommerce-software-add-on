using System.Runtime.Serialization;


namespace activate_woocommerce_software_add_on
{
    [DataContract]
    public class ActivationResponse
    {
        //"activated": true
        //"instance": 1473192358
        //"message": "2 out of 5 activations remaining"
        //"timestamp": 1473192358
        //"errorcode": 101
        //"errrormessage": Invalid license key...
        //"sig": "secret=null&activated=true&instance=1473192358&message=2 out of 5 activations remaining&timestamp=1473192358"

        [DataMember(Name = "activated")]
        public bool Activated { get; set; }

        [DataMember(Name = "instance")]
        public int Instance { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        [DataMember(Name = "sig")]
        public string Sig { get; set; }

        [DataMember(Name = "code")]
        public string ErrorCode { get; set; }

        [DataMember(Name = "error")]
        public string ErrorMessage { get; set; }
    }

}
