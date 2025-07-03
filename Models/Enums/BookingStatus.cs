namespace Models.Enums
{
    public enum BookingStatus
    {
        Panding, // Client Booked but owner still waiting
        Confirmed, // Owner confirmed booking
        Rejected, //Owner reject because problems in property
        Cancel ,// Client withdraw from booking
        All,
        Done, // Client finished his time
        PaymentConfirmed // Client payed to owner account
    }
}
