namespace StripePaymentService.Requests
{
    /// <summary>
    /// Request for payment.
    /// </summary>
    public record PaymentRequest
    {
        /// <summary>
        /// The URL of the success page, if payment is successful.
        /// </summary>
        public string SuccessUrl { get; set; }

        /// <summary>
        /// The URL of the cancel page, if payment is cancelled.
        /// </summary>
        public string CancelUrl { get; set; }

        /// <summary>
        /// The email address of the customer.
        /// </summary>
        public string? CusttomerEmail { get; set; }

        /// <summary>
        /// The currency of the payment. For example, USD. Use uppercase letters.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The name of the order for which payment is being made.
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// The amount of the order for which payment is being made.
        /// Stripe does not accept payments under $1.
        /// Stripe does not accept payments in floating point numbers, such as $10.20. So
        /// you need to send the amount not in a monetary unit (for example, a dollar), 
        /// but in a derivative monetary unit (for example, a cent)..
        /// </summary>
        public long UnitAmount { get; set; }

        /// <summary>
        /// Quantity of orders to be paid.
        /// </summary>
        public int Quantity { get; set; }
    }
}