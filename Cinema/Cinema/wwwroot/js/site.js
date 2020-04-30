let cartOpen = false;
let ids = [];
function selectSeat(seatbutton, id, rownumber, seatnumber) {
    if (!cartOpen) {
        $('.checkout')[0].style.display = 'block';
    }
    cartOpen = true;
    seatbutton.classList.add('selectedSeat');
    var prevText = document.getElementsByClassName('buyingTickets')[0].innerHTML;
    document.getElementsByClassName('buyingTickets')[0].innerHTML = prevText + '<br>' + 'Ticket with row number '
        + rownumber + ' and seat number ' + seatnumber;
    ids.push(id)

}
