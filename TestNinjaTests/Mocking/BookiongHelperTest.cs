using TestNinja.Mocking;
using TestNinja.Mocking.Refactored;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestNinjaTests.Mocking
{
    public class BookingHelperTest_OverlappingBookingsExist
    {
        
        // Non-Overlapping Tests

        [Fact]
        public void BookingEndsBeforeExistingBooking_ReturnsEmptyString()
        {
            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository
            .Setup(br => br.GetActiveBookings(1))
            .Returns(
                new List<Booking> {
                    new Booking {Id = 2, ArrivalDate = new DateTime(2020, 1, 5), DepartureDate = new DateTime(2020, 1, 10)}
                }.AsQueryable()
            );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking {Id = 1, ArrivalDate = new DateTime(2020, 1, 3), DepartureDate = new DateTime(2020, 1, 4) }
                ,bookingRepository.Object
            );

            Assert.Equal(string.Empty, result);

        } 
        
        [Fact]
        public void BookingStartsAfterExistingBooking_ReturnsEmptyString()
        {
            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository
            .Setup(br => br.GetActiveBookings(1))
            .Returns(
                new List<Booking> {
                    new Booking {Id = 2, ArrivalDate = new DateTime(2020, 1, 5), DepartureDate = new DateTime(2020, 1, 10)}
                }.AsQueryable()
            );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking {Id = 1, ArrivalDate = new DateTime(2020, 1, 11), DepartureDate = new DateTime(2020, 1, 12) }
                ,bookingRepository.Object
            );

            Assert.Equal(string.Empty, result);

        } 


        // Overlapping Bookings
        [Fact]
        public void BookingEndsBetweenExistingBooking_ReturnsReference()
        {
            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository
            .Setup(br => br.GetActiveBookings(1))
            .Returns(
                new List<Booking> {
                    new Booking {Id = 2, Reference = "Reference-111", ArrivalDate = new DateTime(2020, 1, 5), DepartureDate = new DateTime(2020, 1, 10)}
                }.AsQueryable()
            );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking {Id = 1, ArrivalDate = new DateTime(2020, 1, 4), DepartureDate = new DateTime(2020, 1, 6) }
                ,bookingRepository.Object
            );

            Assert.Equal("Reference-111", result);

        }

        [Fact]
        public void BookingBetweenExistingBooking_ReturnsReference()
        {
            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository
            .Setup(br => br.GetActiveBookings(1))
            .Returns(
                new List<Booking> {
                    new Booking {Id = 2, Reference = "Reference-111", ArrivalDate = new DateTime(2020, 1, 5), DepartureDate = new DateTime(2020, 1, 10)}
                }.AsQueryable()
            );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking {Id = 1, ArrivalDate = new DateTime(2020, 1, 4), DepartureDate = new DateTime(2020, 1, 8) }
                ,bookingRepository.Object
            );

            Assert.Equal("Reference-111", result);

        }

        [Fact]
        public void BookingStartsBetweenExistingBooking_ReturnsReference()
        {
            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository
            .Setup(br => br.GetActiveBookings(1))
            .Returns(
                new List<Booking> {
                    new Booking {Id = 2, Reference = "Reference-111", ArrivalDate = new DateTime(2020, 1, 5), DepartureDate = new DateTime(2020, 1, 10)}
                }.AsQueryable()
            );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking {Id = 1, ArrivalDate = new DateTime(2020, 1, 8), DepartureDate = new DateTime(2020, 1, 12) }
                ,bookingRepository.Object
            );

            Assert.Equal("Reference-111", result);

        }

        [Fact]
        public void CancelledBooking_ReturnsEmptyString()
        {
            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository
            .Setup(br => br.GetActiveBookings(1))
            .Returns(
                new List<Booking> {
                    new Booking {Id = 2, Reference = "Reference-111", ArrivalDate = new DateTime(2020, 1, 5), DepartureDate = new DateTime(2020, 1, 10)}
                }.AsQueryable()
            );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking {Id = 1, ArrivalDate = new DateTime(2020, 1, 8), DepartureDate = new DateTime(2020, 1, 12), Status = "Cancelled" }
                ,bookingRepository.Object
            );

            Assert.Equal(string.Empty, result);

        }
        

    }
}