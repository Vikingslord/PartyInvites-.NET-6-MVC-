namespace PartyInvites.Models.Repository
{
    public static class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses
        {
            get{ 
                return responses;
            }
        }

        public static void AddResponse(GuestResponse guestResponse)
        {
            responses.Add(guestResponse);
        }
    }
}
