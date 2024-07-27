/*
 *   This is free and unencumbered software released into the public domain.

 *   Anyone is free to copy, modify, publish, use, compile, sell, or
 *   distribute this software, either in source code form or as a compiled
 *   binary, for any purpose, commercial or non-commercial, and by any
 *   means.

 *   For more information, please visit https://github.com/hanav00.
 */

using System;

namespace Chart.Model
{
    public class GymDiscountData
    {
        public int Month { get; set; }
        public int RegistrationMonths { get; set; }
        public double Price { get; set; }
        public bool IsSportWearFree { get; set; }

        public GymDiscountData(int month, int registrationMonths, double price, bool isSportWearFree)
        {
            Month = month;
            RegistrationMonths = registrationMonths;
            Price = price;
            IsSportWearFree = isSportWearFree;
        }
    }
}
