
/* Slider */
$(document).ready(function(){
    $('.slider-for').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav',
        autoplay: true
    });
    $('.slider-nav').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    asNavFor: '.slider-for',
    dots: false,
    centerMode: true,
    focusOnSelect: true
    });
});
/*End*/

/*Payment*/
$(function() {
    var $tabButtonItem = $('#tab-button li'),
        $tabSelect = $('#tab-select'),
        $tabContents = $('.tab-contents'),
        activeClass = 'is-active';
  
    $tabButtonItem.first().addClass(activeClass);
    $tabContents.not(':first').hide();
  
    $tabButtonItem.find('a').on('click', function(e) {
      var target = $(this).attr('href');
  
      $tabButtonItem.removeClass(activeClass);
      $(this).parent().addClass(activeClass);
      $tabSelect.val(target);
      $tabContents.hide();
      $(target).show();
      e.preventDefault();
    });
  
    $tabSelect.on('change', function() {
      var target = $(this).val(),
          targetSelectNum = $(this).prop('selectedIndex');
  
      $tabButtonItem.removeClass(activeClass);
      $tabButtonItem.eq(targetSelectNum).addClass(activeClass);
      $tabContents.hide();
      $(target).show();
    });
  });


  $(function() {
    $('form.require-validation').bind('submit', function(e) {
      var $form         = $(e.target).closest('form'),
          inputSelector = ['input[type=email]', 'input[type=password]',
                           'input[type=text]', 'input[type=file]',
                           'textarea'].join(', '),
          $inputs       = $form.find('.required').find(inputSelector),
          $errorMessage = $form.find('div.error'),
          valid         = true;
  
      $errorMessage.addClass('hide');
      $('.has-error').removeClass('has-error');
      $inputs.each(function(i, el) {
        var $input = $(el);
        if ($input.val() === '') {
          $input.parent().addClass('has-error');
          $errorMessage.removeClass('hide');
          e.preventDefault(); // cancel on first error
        }
      });
    });
  });
  
  $(function() {
    var $form = $("#payment-form");
  
    $form.on('submit', function(e) {
      if (!$form.data('cc-on-file')) {
        e.preventDefault();
        Stripe.setPublishableKey($form.data('stripe-publishable-key'));
        Stripe.createToken({
          number: $('.card-number').val(),
          cvc: $('.card-cvc').val(),
          exp_month: $('.card-expiry-month').val(),
          exp_year: $('.card-expiry-year').val()
        }, stripeResponseHandler);
      }
    });
  
    function stripeResponseHandler(status, response) {
      if (response.error) {
        $('.error')
          .removeClass('hide')
          .find('.alert')
          .text(response.error.message);
      } else {
        // token contains id, last4, and card type
        var token = response['id'];
        // insert the token into the form so it gets submitted to the server
        $form.find('input[type=text]').empty();
        $form.append("<input type='hidden' name='reservation[stripe_token]' value='" + token + "'/>");
        $form.get(0).submit();
      }
    }
  })
  /*End*/

  /*Login*/
jQuery(function ($) {
    "use strict";


    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

});
  /*End*/



$("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});


$(document).ready(function() {
    var results = $.getJSON("https://restcountries.eu/rest/v2/all", function(data) {

        for(var i = 0; i < data.length; i++) {
            $("#cities").append('<option value="' + data[i].name + '">' + data[i].name + '</option>');
        }
    });
});

console.log('hello');