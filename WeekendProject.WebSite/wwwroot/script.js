var doc = document;

var buttons = doc.querySelectorAll('.buy');
var popup_buy = doc.querySelector('.modal');
doc.querySelector('.close_popup_btn').onclick = function(){
	popup_buy.classList.remove('modal--show');
}

function popup_buy_view(button, buy){
button.addEventListener('click', function () {
	buy.classList.add('modal--show');
});
}
 for (var i = 0; i < buttons.length; i++) {
	popup_buy_view(buttons[i], popup_buy);
}
