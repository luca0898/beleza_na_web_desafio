using System.Runtime.Serialization;

namespace BelezanaWeb.SystemObjects.ViewModel
{
    public class SuccessResponseViewModel<TData>
    {
        [DataMember(Name = "data")]
        public TData Data { get; set; }

        public SuccessResponseViewModel(TData data)
        {
            Data = data;
        }
    }
}
