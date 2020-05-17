$(document).ready(function () {
    $('#Workers').DataTable();
    $('#Movies').DataTable();
    $('#CinemaLocation').DataTable();
    $('#FoodAmountsTable').DataTable();
    $('#CinemaHalll').DataTable();
    $('#ShowingsTable').DataTable();
    if ($('#allfoods').length > 0) {
        FoodcourtDefault();
    }
});

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
            alert("sed");
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
            alert("sed");
            window.open(`/Foodcourt/CreatePDFCheck/${m}`, "_blank");
        }
    });
}