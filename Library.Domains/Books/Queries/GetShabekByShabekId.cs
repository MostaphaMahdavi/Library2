using MediatR;

namespace Library.Domains.Books.Queries
{
    public class GetShabekByShabekId:IRequest<bool>
    {
        public string ShabekNo { get; set; }

        public GetShabekByShabekId(string shabekNo)
        {
            ShabekNo = shabekNo;
        }
    }
}