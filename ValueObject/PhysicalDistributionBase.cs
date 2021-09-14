using System;

namespace ValueObject
{
    /// <summary>
    /// 物流拠点Entity
    /// </summary>
    public class PhysicalDistributionBase
    {
        public Baggage Ship(Baggage baggage)
        {
            // 略
            throw new NotImplementedException();
        }

        public void Receive(Baggage baggage)
        {
        }

        public void Transport(PhysicalDistributionBase to, Baggage baggage)
        {
            var shippedBaggage = Ship(baggage);
            to.Receive(shippedBaggage);
        }
    }

    public class Baggage
    {
    }

    public class TransportService
    {
        public void Transport(PhysicalDistributionBase from, PhysicalDistributionBase to, Baggage baggage)
        {
            var shippedBaggage = from.Ship(baggage);
            to.Receive(shippedBaggage);

            // 配送の記録を行う
            // 略
        }
    }
}