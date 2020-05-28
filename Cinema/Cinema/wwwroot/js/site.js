$(document).ready(function () {
    $('#Workers').DataTable();
    $('#Movies').DataTable();
    $('#CinemaLocation').DataTable();
    $('#FoodAmountsTable').DataTable();
    $('#CinemaHallTable').DataTable();
    $('#ShowingsTable').DataTable();
    if ($('#allfoods').length > 0) {
        FoodcourtDefault();
    }
});
function isValidFoodAmountEdit() {
    var number = $('#FoodAmountEdit').val();
    $('#FoodAmountEditMistake').css('display', 'none');
    $('#FoodAmountCreateAmountMistake2').css('display', 'none');
    if (number.length == 0) {
        if (number.length == 0) {
            $('#FoodAmountEditMistake').css('display', 'block');
        } else {
            $('#FoodAmountEditMistake').css('display', 'none');
        }
        return false;
    } else {
        if (!Number.parseInt(number)) {
            $('#FoodAmountCreateAmountMistake2').css('display', 'block');
            return false;
        } else {
            $('#FoodAmountCreateAmountMistake2').css('display', 'none');
        }
        return true;
    }
}
function isValidFoodAmountCreate() {
    var number = $('#FoodAmountCreateAmount').val();
    $('#FoodAmountCreateAmountMistake').css('display', 'none');
    $('#FoodAmountCreateAmountMistake2').css('display', 'none');
    if (number.length == 0) {
        if (number.length == 0) {
            $('#FoodAmountCreateAmountMistake').css('display', 'block');
        } else {
            $('#FoodAmountCreateAmountMistake').css('display', 'none');
        }
        return false;
    } else {
        if (!Number.parseInt(number) ) {
            $('#FoodAmountCreateAmountMistake2').css('display', 'block');
            return false;
        } else {
            $('#FoodAmountCreateAmountMistake2').css('display', 'none');
        }
        return true;
    }
}
function isValidShowingEdit() {
    var dateAndTime = $('#ShowingEditDate').val();
    if (dateAndTime.length == 0) {
        if (dateAndTime.length == 0) {
            $('#ShowingEditDateMistake').css('display', 'block');
        } else {
            $('#ShowingEditDateMistake').css('display', 'none');
        }
        return false;
    } else {
        return true;
    }
}
function isValidShowingCreate() {
    var dateAndTime = $('#ShowingCreateDate').val();
    if (dateAndTime.length == 0 ) {
        if (dateAndTime.length == 0) {
            $('#ShowingCreateDateMistake').css('display', 'block');
        } else {
            $('#ShowingCreateDateMistake').css('display', 'none');
        }
        return false;
    } else {
        return true;
    }
}
function isValidMovieEdit() {
    var title = $('#EditMovieTitle').val();
    var countryOfOrigin = $('#EditMovieCountryOfOrigin').val();
    var director = $('#EditMovieDirector').val();
    var premiere = $('#EditMoviePremiere').val();
    var end = $('#EditMovieEndDate').val();
    var lengthM = $('#EditMovieLength').val();
    var poster = $('#EditMoviePoster').val();
    if (title.length == 0 || countryOfOrigin.length == 0 || director.length == 0 ||
        premiere.length == 0 || end.length == 0 || lengthM.length == 0 ||
        poster.length == 0) {
        if (title.length == 0) {
            $('#EditMovieTitleMistake').css('display', 'block');
        } else {
            $('#EditMovieTitleMistake').css('display', 'none');
        }
        if (countryOfOrigin.length == 0) {
            $('#EditMovieCountryOfOriginMistake').css('display', 'block');
        } else {
            $('#EditMovieCountryOfOriginMistake').css('display', 'none');
        }
        if (director.length == 0) {
            $('#EditMovieDirectorMistake').css('display', 'block');
        } else {
            $('#EditMovieDirectorMistake').css('display', 'none');
        }
        if (premiere.length == 0) {
            $('#EditMoviePremiereMistake').css('display', 'block');
        } else {
            $('#EditMoviePremiereMistake').css('display', 'none');
        }
        if (end.length == 0) {
            $('#EditMovieEndDateMistake').css('display', 'block');
        } else {
            $('#EditMovieEndDateMistake').css('display', 'none');
        }
        if (lengthM.length == 0) {
            $('#EditMovieLengthMistake').css('display', 'block');
        } else {
            $('#EditMovieLengthMistake').css('display', 'none');
        }
        if (poster.length == 0) {
            $('#EditMoviePosterMistake').css('display', 'block');
        } else {
            $('#EditMoviePosterMistake').css('display', 'none');
        }
        return false;
    } else {
        return true;
    }
}
function isValidMovieCreate() {
    var title = $('#MovieCreateTitle').val();
    var countryOfOrigin = $('#MovieCreateCountryOfOrigin').val();
    var director = $('#MovieCreateDirector').val();
    var premiere = $('#MovieCreatePremiere').val();
    var end = $('#MovieCreateEndDate').val();
    var lengthM = $('#MovieCreateLength').val();
    var poster = $('#MovieCreatePoster').val();
    if (title.length == 0 || countryOfOrigin.length == 0 || director.length == 0 ||
        premiere.length == 0 || end.length == 0 || lengthM.length == 0 ||
        poster.length == 0 ) {
        if (title.length == 0) {
            $('#MovieCreateTitleMistake').css('display', 'block');
        } else {
            $('#MovieCreateTitleMistake').css('display', 'none');
        }
        if (countryOfOrigin.length == 0) {
            $('#MovieCreateCountryOfOriginMistake').css('display', 'block');
        } else {
            $('#MovieCreateCountryOfOriginMistake').css('display', 'none');
        }
        if (director.length == 0) {
            $('#MovieCreateDirectorMistake').css('display', 'block');
        } else {
            $('#MovieCreateDirectorMistake').css('display', 'none');
        }
        if (premiere.length == 0) {
            $('#MovieCreatePremiereMistake').css('display', 'block');
        } else {
            $('#MovieCreatePremiereMistake').css('display', 'none');
        }
        if (end.length == 0) {
            $('#MovieCreateEndDateMistake').css('display', 'block');
        } else {
            $('#MovieCreateEndDateMistake').css('display', 'none');
        }
        if (lengthM.length == 0) {
            $('#MovieCreateLengthMistake').css('display', 'block');
        } else {
            $('#MovieCreateLengthMistake').css('display', 'none');
        }
        if (poster.length == 0) {
            $('#MovieCreatePosterMistake').css('display', 'block');
        } else {
            $('#MovieCreatePosterMistake').css('display', 'none');
        }
        return false;
    } else {
        return true;
    }
}
function isValidEditCinemaHall() {
    var name = $('#CinemaHallEditName').val();
    var rows = $('#CinemaHallEditRows').val();
    var seats = $('#CinemaHallEditSeats').val();
    if (name.length == 0 || rows.length == 0 || seats.length == 0) {
        if (name.length == 0) {
            $('#CinemaHallEditNameMistake').css('display', 'block');
        } else {
            $('#CinemaHallEditNameMistake').css('display', 'none');
        }
        if (rows.length == 0) {
            $('#CinemaHallEditRowsMistake').css('display', 'block');
        } else {
            $('#CinemaHallEditRowsMistake').css('display', 'none');
            if (!Number.parseInt(rows)) {
                $('#CreateCinemaHallRowsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallRowsMistake2').css('display', 'none');
            }
        }
        if (seats.length == 0) {
            $('#CinemaHallEditSeatsMistake').css('display', 'block');
        } else {
            $('#CinemaHallEditSeatsMistake').css('display', 'none');
            if (!Number.parseInt(seats)) {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'none');
            }
        }
        return false;
    } else {
        if (!Number.parseInt(rows) || !Number.parseInt(seats)) {
            if (!Number.parseInt(rows)) {
                $('#CreateCinemaHallRowsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallRowsMistake2').css('display', 'none');
            }
            if (!Number.parseInt(seats)) {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'none');
            }
            return false;
        }
        return true;
    }
}
function isValidCreateCinemaHall() {
    var name = $('#CreateCinemaHallName').val();
    var rows = $('#CreateCinemaHallRows').val();
    var seats = $('#CreateCinemaHallSeats').val();
    if (name.length == 0 || rows.length == 0 || seats.length == 0) {
        if (name.length == 0) {
            $('#CreateCinemaHallNameMistake').css('display', 'block');
        } else {
            $('#CreateCinemaHallNameMistake').css('display', 'none');
        }
        if (rows.length == 0) {
            $('#CreateCinemaHallRowsMistake').css('display', 'block');
        } else {
            $('#CreateCinemaHallRowsMistake').css('display', 'none');
            if (!Number.parseInt(rows)) {
                $('#CreateCinemaHallRowsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallRowsMistake2').css('display', 'none');
            }
        }
        if (seats.length == 0) {
            $('#CreateCinemaHallSeatsMistake').css('display', 'block');
        } else {
            $('#CreateCinemaHallSeatsMistake').css('display', 'none');
            if (!Number.parseInt(seats)) {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'none');
            }
        }
        return false;
    } else {
        if (!Number.parseInt(rows) || !Number.parseInt(seats)) {
            if (!Number.parseInt(rows)) {
                $('#CreateCinemaHallRowsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallRowsMistake2').css('display', 'none');
            }
            if (!Number.parseInt(seats)) {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'block');
            } else {
                $('#CreateCinemaHallSeatsMistake2').css('display', 'none');
            }
            return false;
        }
        return true;
    }
}
function isValidEditCinema() {
    var cinema = $('#CinemaEditCinemaName').val();
    var city = $('#CinemaEditCity').val();
    var address = $('#CinemaEditAddress').val();
    if (cinema.length == 0 || city.length == 0 || address.length == 0) {
        if (cinema.length == 0) {
            $('#CinemaEditCinemaNameMistake').css('display', 'block');
        } else {
            $('#CinemaEditCinemaNameMistake').css('display', 'none');
        }
        if (city.length == 0) {
            $('#CinemaEditCityMistake').css('display', 'block');
        } else {
            $('#CinemaEditCityMistake').css('display', 'none');
        }
        if (address.length == 0) {
            $('#CinemaEditAddressMistake').css('display', 'block');
        } else {
            $('#CinemaEditAddressMistake').css('display', 'none');
        }
        return false;
    } else {
        return true;
    }
}
function isValidCreateCinema() {
    var cinema = $('#CinemaCreateCinemaName').val();
    var city = $('#CinemaCreateCity').val();
    var address = $('#CinemaCreateAddress').val();
    if (cinema.length == 0 || city.length == 0 || address.length == 0) {
        if (cinema.length == 0) {
            $('#CinemaCreateCinemaNameMistake').css('display', 'block');
        } else {
            $('#CinemaCreateCinemaNameMistake').css('display', 'none');
        }
        if (city.length == 0) {
            $('#CinemaCreateCityMistake').css('display', 'block');
        } else {
            $('#CinemaCreateCityMistake').css('display', 'none');
        }
        if (address.length == 0) {
            $('#CinemaCreateAddressMistake').css('display', 'block');
        } else {
            $('#CinemaCreateAddressMistake').css('display', 'none');
        }       
        return false;
    } else {
        return true;
    }
}
function isValidRegister() {
    var login = $('#loginReg').val();
    var password = $('#passportReg').val();
    var name = $('#nameReg').val();
    var surname = $('#surnameReg').val();
    var fathername = $('#fathernameReg').val();
    var passportData = $('#passportReg').val();
    if (login.length == 0 || passportData.length != 8 || password.length == 0 ||name.length == 0 || surname.length == 0 || fathername.length == 0 || passportData.length == 0) {
        if (login.length == 0) {
            $('#loginRegMistake').css('display', 'block');
        } else {
            $('#loginRegMistake').css('display', 'none');
        }
        if (password.length == 0) {
            $('#passportRegMistake').css('display', 'block');
        } else {
            $('#passportRegMistake').css('display', 'none');
        }
        if (name.length == 0) {
            $('#nameRegMistake').css('display', 'block');
        } else {
            $('#nameRegMistake').css('display', 'none');
        }
        if (surname.length == 0) {
            $('#surnameRegMistake').css('display', 'block');
        } else {
            $('#surnameRegMistake').css('display', 'none');
        }
        if (fathername.length == 0) {
            $('#fathernameRegMistake').css('display', 'block');
        } else {
            $('#fathernameRegMistake').css('display', 'none');
        }
        if (passportData.length == 0) {
            $('#passportRegMistake').css('display', 'block');
        } else {
            $('#passportRegMistake').css('display', 'none');
            if (passportData.length != 8) {
                $('#passportRegMistake2').css('display', 'block');
            } else {
                $('#passportRegMistake2').css('display', 'none');
            }
            var letterString = passportData.substring(0, 2);
            var numberString = passportData.substring(2, 8);
            if (Number.parseInt(letterString) || !Number.parseInt(numberString)) {
                $('#passportRegMistake2').css('display', 'block');
            } else {
                $('#passportRegMistake2').css('display', 'none');
            }
        }
        
        return false;
    } else {
        var letterString = passportData.substring(0, 2);
        var numberString = passportData.substring(2, 8);
        if (Number.parseInt(letterString) || !Number.parseInt(numberString)) {
            $('#passportRegMistake2').css('display', 'block');
            return false;
        } else {
            $('#passportRegMistake2').css('display', 'none');
        }
        return true;
    }
}
function isValidProfileFull() {
    var name = $('#nameFull').val();
    var surname = $('#surnameFull').val();
    var fathername = $('#fathernameFull').val();
    var passportData = $('#passportDataFull').val();
    if (name.length == 0 || surname.length == 0 || passportData.length != 8  || fathername.length == 0 || passportData.length == 0) {
        if (name.length == 0) {
            $('#nameFullMistake').css('display', 'block');
        } else {
            $('#nameFullMistake').css('display', 'none');
        }
        if (surname.length == 0) {
            $('#surnameFullMistake').css('display', 'block');
        } else {
            $('#surnameFullMistake').css('display', 'none');
        }
        if (fathername.length == 0) {
            $('#fathernameFullMistake').css('display', 'block');
        } else {
            $('#fathernameFullMistake').css('display', 'none');
        }
        if (passportData.length == 0) {
            $('#passportDataFullMistake').css('display', 'block');
        } else {
            $('#passportDataFullMistake').css('display', 'none');
            if (passportData.length != 8) {
                $('#passportDataFullMistake2').css('display', 'block');
            } else {
                $('#passportDataFullMistake2').css('display', 'none');
            }
            var letterString = passportData.substring(0, 2);
            var numberString = passportData.substring(2, 8);
            if (Number.parseInt(letterString) || !Number.parseInt(numberString)) {
                $('#passportDataFullMistake2').css('display', 'block');
            } else {
                $('#passportDataFullMistake2').css('display', 'none');
            }
        }
        
        return false;
    } else {
        var letterString = passportData.substring(0, 2);
        var numberString = passportData.substring(2, 8);
        if (Number.parseInt(letterString) || !Number.parseInt(numberString)) {
            $('#passportDataFullMistake2').css('display', 'block');
            return false;
        } else {
            $('#passportDataFullMistake2').css('display', 'none');
        }
        return true;
    }
}
function isValidProfileLimited() {
    var name = $('#limName').val();
    var surname = $('#limSurname').val();
    var fathername = $('#limFathername').val();
    var passportData = $('#limPassportData').val();
    if (name.length == 0 || surname.length == 0 || fathername.length == 0 || passportData.length == 0 || passportData.length != 8) {
        if (name.length == 0) {
            $('#limNameMistake').css('display', 'block');
        } else {
            $('#limNameMistake').css('display', 'none');
        }
        if (surname.length == 0) {
            $('#limSurnameMistake').css('display', 'block');
        } else {
            $('#limSurnameMistake').css('display', 'none');
        }
        if (fathername.length == 0) {
            $('#limFathernameMistake').css('display', 'block');
        } else {
            $('#limFathernameMistake').css('display', 'none');
        }
        if (passportData.length == 0) {
            $('#limPassportDataMistake').css('display', 'block');
        } else {
            $('#limPassportDataMistake').css('display', 'none');
            if (passportData.length != 8) {
                $('#limPassportDataMistake2').css('display', 'block');
            } else {
                $('#limPassportDataMistake2').css('display', 'none');
            }
            var letterString = passportData.substring(0, 2);
            var numberString = passportData.substring(2, 8);
            if (Number.parseInt(letterString) || !Number.parseInt(numberString)) {
                $('#limPassportDataMistake2').css('display', 'block');
            } else {
                $('#limPassportDataMistake2').css('display', 'none');
            }
        }
        
        return false;
    } else {
        var letterString = passportData.substring(0, 2);
        var numberString = passportData.substring(2, 8);
        if (Number.parseInt(letterString) || !Number.parseInt(numberString) ){
            $('#limPassportDataMistake2').css('display', 'block');
            return false;
        } else {
            $('#limPassportDataMistake2').css('display', 'none');
        }
        return true;
    }
}

function isValidLogin() {
    var loginF = $('#loginField').val(); 
    var passwordF = $('#passwordField').val();
    if (loginF.length == 0 || passwordF.length == 0) {
        if (loginF.length == 0) {
            $('#login').css('display', 'block');
        } else {
            $('#login').css('display', 'none');
        }
        if (passwordF.length == 0) {
            $('#password').css('display', 'block');
        } else {
            $('#login').css('display', 'none');
        }
        return false;
    } else {
        return true;
    }
}

function DisplayShowings() {
    var sel = document.getElementById('MovieSelection');
    var allfoodsclasses = $('.showingsbyCinema');
    for (var i = 0; i < allfoodsclasses.length; ++i) {
        allfoodsclasses[i].style.display = 'none';
    }
    allfoodsclasses[sel.value].style.display = 'block';
}

let cartOpen = false;
let ids = [];
let movieMoney = 0;
function selectSeat(seatbutton, id, rownumber, seatnumber, money) {
    if (!cartOpen) {
        $('.checkout')[0].style.display = 'block';
    }
    cartOpen = true;
    var prevText = document.getElementsByClassName('buyingTickets')[0].innerHTML;
    if (seatbutton.classList.contains('selectedSeat')) {
        if (seatbutton.classList.length == 0) {
            $('.checkout')[0].style.display = 'none';
        }
        return;
    }
    if (seatbutton.classList.contains('pickedSeat')) {
        seatbutton.classList.remove('pickedSeat');
        var newString = '<br>' + 'Ticket with row number '
            + rownumber + ' and seat number ' + seatnumber;
        var ret = prevText.replace(newString, '');
        document.getElementsByClassName('buyingTickets')[0].innerHTML = ret;
        movieMoney -= money;
        ids = ids.filter(x => x != id);
    } else {
        seatbutton.classList.add('pickedSeat');

        document.getElementsByClassName('buyingTickets')[0].innerHTML = prevText + '<br>' + 'Ticket with row number '
            + rownumber + ' and seat number ' + seatnumber;
        movieMoney += money;
        ids.push(id);
    }
    

}
function BuyMovie() {
    var dataItem = { TicketIds: ids, money: movieMoney};
    $.post({
        type: 'POST',
        data: JSON.stringify(dataItem),
        url: '/Movie/Buy',
        contentType: 'application/json; charset=utf-8'
    }).done(m => {
        if (m > 0) {
            window.open(`/Movie/CreatePDF/${m}`, "_blank");
        }
    });
}

function FoodcourtDefault() {
    var sel = document.getElementById('allfoods');
    var allfoodsclasses = $('.allfoodswrapper');
    for (var i = 0; i < allfoodsclasses.length; ++i) {
        allfoodsclasses[i].style.display = 'none';
    }
    allfoodsclasses[0].style.display = 'block';

    $('.onefood')[0].style.display = 'none';
    $('.checkoutFood')[0].style.display = 'none';
}

function DisplayFood() {
    var sel = document.getElementById('allfoods');
    var allfoodsclasses = $('.allfoodswrapper');
    for (var i = 0; i < allfoodsclasses.length; ++i) {
        allfoodsclasses[i].style.display = 'none';
    }
    allfoodsclasses[sel.value].style.display = 'block';

    $('.onefood')[0].style.display = 'none';
    $('.checkoutFood')[0].style.display = 'none';
    food = [];
}


function ChooseOneFood(foodname, foodamount, Id, foodprice) {
    $('.onefood')[0].style.display = 'block';
    $('.foodname').html(foodname);
    $('.foodprice').html(foodprice);
    $('.foodamount').html(foodamount);
    $('.foodId').html(Id);
    $('#amount').html('1');
}

function RemoveProducts() {
    var amount = parseInt($('#amount').html().toString());
    amount--;
    if (amount < 1) {
        $('#amount').html('1');
    } else {
        $('#amount').html(amount);
    }
}

function AddProducts() {
    var amount = parseInt($('#amount').html().toString());
    var maxAmount = parseInt($('.foodamount').html().toString());
    amount++;
    if (amount > maxAmount) {
        $('#amount').html(maxAmount);
    } else {
        $('#amount').html(amount);
    }
}

let food = [];
function AddToCheckout() {
    $('.checkoutFood')[0].style.display = 'block';
    var tempString = $('.foodname').html();
    var amount = parseInt($('#amount').html().toString());
    var maxAmount = parseInt($('.foodamount').html().toString());
    var Price = parseFloat($('.foodprice').html().toString());
    var Id = parseInt($('.foodId').html().toString());
    var myBool = false;
    var foundIndex = 0;
    
    if (food.length < 1) {
        let tempArr = [];
        var tempString = $('.foodname').html();
        tempArr.push(tempString);
        var amount = parseInt($('#amount').html().toString());
        tempArr.push(amount);
        var maxAmount = parseInt($('.foodamount').html().toString());
        tempArr.push(maxAmount);
        tempArr.push(Price);
        tempArr.push(Id);
        food.push(tempArr);
        $('#shopcart').children().remove();
        jQuery.each(food, (index, value) => {
            $('<p/>', {
                'text': value[0] + '   Items: ' + value[1] + '. Cost - ' + value[3] * value[1],
                'class': 'allcartFood',
                'click': () => EditFood(value)
            }).appendTo($('#shopcart'));
        })
        let totalCost = 0;
        for (var i = 0; i < food.length; ++i) {
            totalCost += food[i][3] * food[i][1];
        }
        $('#totalFoodCost').html('Total check cost - ' + totalCost);
    } else {
        for (var i = 0; i < food.length; ++i) {
            if (food[i][0] === tempString) {
                myBool = true;
                foundIndex = i;
                break;
            }
        }
        if (myBool) {
            var newAmount = food[foundIndex][1] + amount;
            if (newAmount > maxAmount) {
                alert('The requested amount of ' + food[foundIndex][0] + ' cannot be provided. Please choose a different amount');
                return;
            } else {
                food[foundIndex][1] = newAmount;
                $('#shopcart').children().remove();
                jQuery.each(food, (index, value) => {
                    $('<p/>', {
                        'text': value[0] + '   Items: ' + value[1] + '. Cost - ' + value[3] * value[1],
                        'class': 'allcartFood',
                        'click': () => EditFood(value)
                    }).appendTo($('#shopcart'));
                })
                let totalCost = 0;
                for (var i = 0; i < food.length; ++i) {
                    totalCost += food[i][3] * food[i][1];
                }
                $('#totalFoodCost').html('Total check cost - ' + totalCost);
            }
        } else {
            let tempArr = [];
            var tempString = $('.foodname').html();
            tempArr.push(tempString);
            var amount = parseInt($('#amount').html().toString());
            tempArr.push(amount);
            var maxAmount = parseInt($('.foodamount').html().toString());
            tempArr.push(maxAmount);
            tempArr.push(Price);
            tempArr.push(Id);
            food.push(tempArr);
            $('#shopcart').children().remove();
            jQuery.each(food, (index, value) => {
                $('<p/>', {
                    'text': value[0] + '   Items: ' + value[1] + '. Cost - ' + value[3] * value[1],
                    'class': 'allcartFood',
                    'click': () => EditFood(value)
                }).appendTo($('#shopcart'));
            })
            let totalCost = 0;
            for (var i = 0; i < food.length; ++i) {
                totalCost += food[i][3] * food[i][1];
            }
            $('#totalFoodCost').html('Total check cost - ' + totalCost);
        }
    }
}
function BuyFood() {
    let totalCost = 0;
    let foodIds = [];
    for (var i = 0; i < food.length; ++i) {
        totalCost += food[i][3] * food[i][1];
        var temp = { Id: food[i][4], Amount: food[i][1] };
        foodIds.push(temp);
    }
    var dataItem = { TicketIds: foodIds, Price: totalCost };
    $.post({
        type: 'POST',
        data: JSON.stringify(dataItem),
        url: '/Foodcourt/BuyFood',
        contentType: 'application/json; charset=utf-8'
    }).done(m => {
        if (m > 0) {
            window.open(`/Foodcourt/CreatePDFCheck/${m}`, "_blank");
        }
    });
}