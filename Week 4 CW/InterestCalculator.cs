using System;

namespace Week_4_CW
{
    /// <summary>
    /// Utility methods for common interest calculations (simple, compound, present value, annuities).
    /// Uses <see cref="decimal"/> for monetary values and accepts annual rates as decimals (e.g. 0.05 for 5%).
    /// </summary>
    public static class InterestCalculator
    {
        /// <summary>
        /// Calculates future value using simple interest:
        /// FV = P * (1 + r * t)
        /// </summary>
        public static decimal FutureValueSimple(decimal principal, decimal annualRate, decimal years)
        {
            ValidateInputs(principal, annualRate, years, allowZeroRate: true);
            return principal * (1 + annualRate * years);
        }

        /// <summary>
        /// Calculates future value using compound interest:
        /// FV = P * (1 + r / n)^(n * t)
        /// </summary>
        public static decimal FutureValueCompound(decimal principal, decimal annualRate, decimal years, int compoundsPerYear = 1)
        {
            ValidateInputs(principal, annualRate, years);
            if (compoundsPerYear <= 0) throw new ArgumentOutOfRangeException(nameof(compoundsPerYear), "Compounds per year must be positive.");

            // Use double for Math.Pow then convert back to decimal.
            double p = (double)principal;
            double r = (double)annualRate;
            double n = compoundsPerYear;
            double t = (double)years;

            double fv = p * Math.Pow(1.0 + r / n, n * t);
            return Decimal.Round((decimal)fv, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calculates present value given a future value, using compound discounting:
        /// PV = FV / (1 + r / n)^(n * t)
        /// </summary>
        public static decimal PresentValue(decimal futureValue, decimal annualRate, decimal years, int compoundsPerYear = 1)
        {
            if (futureValue < 0) throw new ArgumentOutOfRangeException(nameof(futureValue), "Future value cannot be negative.");
            ValidateInputs(1m, annualRate, years); // principal unused here; just validate rate/year
            if (compoundsPerYear <= 0) throw new ArgumentOutOfRangeException(nameof(compoundsPerYear), "Compounds per year must be positive.");

            double fv = (double)futureValue;
            double r = (double)annualRate;
            double n = compoundsPerYear;
            double t = (double)years;

            double pv = fv / Math.Pow(1.0 + r / n, n * t);
            return Decimal.Round((decimal)pv, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Future value of a series of equal periodic contributions (ordinary annuity).
        /// contribution: amount added each period (at period end)
        /// ratePerPeriod: if compoundsPerYear is set, annualRate / compoundsPerYear is used as ratePerPeriod.
        /// Formula: FV = contribution * ( (1 + i)^N - 1 ) / i
        /// </summary>
        public static decimal FutureValueAnnuity(decimal contributionPerPeriod, decimal annualRate, decimal years, int compoundsPerYear = 1, bool annuityDue = false)
        {
            if (contributionPerPeriod < 0) throw new ArgumentOutOfRangeException(nameof(contributionPerPeriod), "Contribution cannot be negative.");
            ValidateInputs(1m, annualRate, years);
            if (compoundsPerYear <= 0) throw new ArgumentOutOfRangeException(nameof(compoundsPerYear), "Compounds per year must be positive.");

            double c = (double)contributionPerPeriod;
            double r = (double)annualRate;
            double n = compoundsPerYear;
            double t = (double)years;

            double i = r / n;
            double N = n * t;

            if (i == 0.0)
            {
                double fv = c * N;
                return Decimal.Round((decimal)fv, 2, MidpointRounding.AwayFromZero);
            }

            double factor = (Math.Pow(1.0 + i, N) - 1.0) / i;
            double fvAnnuity = c * factor;

            if (annuityDue)
            {
                fvAnnuity *= (1.0 + i); // contributions at period start
            }

            return Decimal.Round((decimal)fvAnnuity, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Validates common numeric inputs.
        /// </summary>
        private static void ValidateInputs(decimal principal, decimal annualRate, decimal years, bool allowZeroRate = false)
        {
            if (principal < 0) throw new ArgumentOutOfRangeException(nameof(principal), "Principal cannot be negative.");
            if (years < 0) throw new ArgumentOutOfRangeException(nameof(years), "Years cannot be negative.");
            if (!allowZeroRate && annualRate <= 0) throw new ArgumentOutOfRangeException(nameof(annualRate), "Annual rate must be positive.");
            if (allowZeroRate && annualRate < 0) throw new ArgumentOutOfRangeException(nameof(annualRate), "Annual rate cannot be negative.");
        }
    }
}