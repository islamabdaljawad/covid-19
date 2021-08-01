
/* page1 */
$(".menu-bar").click(function(){
    $(".list").toggleClass("active");
});

/*page3*/
$('.content1').addClass('activeCon');
$('.tab1').attr('disabled','disabled');
$('.tab1').addClass('active2');
var content1 = $('.content1');
var content2 = $('.content2');
var content3 = $('.content3');
var content4 = $('.content4');


$('.tab1').click(function(){   
var activeCon=$('.activeCon');
var activeLine=$('.active2');
activeCon.removeClass('activeCon');
content1.addClass('activeCon');
activeLine.removeClass('active2');
$(this).addClass('active2');
$(this).attr('disabled','disabled');
$('.tab2').removeAttr("disabled");
$('.tab3').removeAttr("disabled");
$('.tab4').removeAttr("disabled");
});


$('.tab2').click(function(){   
var activeCon=$('.activeCon');
var activeLine=$('.active2');
activeCon.removeClass('activeCon');
content2.addClass('activeCon');
activeLine.removeClass('active2');
$(this).addClass('active2');
$(this).attr('disabled','disabled');
$('.tab1').removeAttr("disabled");
$('.tab3').removeAttr("disabled");
$('.tab4').removeAttr("disabled");
});


$('.tab3').click(function(){   
var activeCon=$('.activeCon');
var activeLine=$('.active2');
activeCon.removeClass('activeCon');
content3.addClass('activeCon');
activeLine.removeClass('active2');
$(this).addClass('active2');
$(this).attr('disabled','disabled');
$('.tab1').removeAttr("disabled");
$('.tab2').removeAttr("disabled");
$('.tab4').removeAttr("disabled");
});


$('.tab4').click(function(){   
var activeCon=$('.activeCon');
var activeLine=$('.active2');
activeCon.removeClass('activeCon');
content4.addClass('activeCon');
activeLine.removeClass('active2');
$(this).addClass('active2');
$(this).attr('disabled','disabled');
$('.tab1').removeAttr("disabled");
$('.tab2').removeAttr("disabled");
$('.tab3').removeAttr("disabled");
});


/* page5 */ 

var allData=[];
var state=[];
var tBody=document.getElementById("tableBody");
var httReq = new XMLHttpRequest();
httReq.open("GET", "https://api.covidactnow.org/v2/states.json?apiKey=a8ea6f190c0b409c823bb7959a9c2052");
httReq.send();
httReq.onreadystatechange = function()
{
    if (httReq.readyState == 4 && httReq.status == 200)
    {
       allData=JSON.parse(httReq.response);
       displayData();
    }
} 

function displayData()
{
    var temp = "";
    for(var i=0;i<allData.length;i++ )
    {
        temp +="<tr><td>"+allData[i].state+"</td>  <td>"+allData[i].actuals.newCases+"</td> <td>"+allData[i].actuals.newDeaths+"</td> <td>"+allData[i].actuals.vaccinesDistributed+"</td> <td>"+allData[i].actuals.vaccinationsCompleted+"</td> </tr>"
    }
    document.getElementById("tableBody").innerHTML=temp;
}


/* page6  */ 

var allData2=[];
var httReq2 = new XMLHttpRequest();
httReq2.open("GET", "https://gnews.io/api/v4/top-headlines?token=ea372438bb02af5ae3e94c38c6c4f285&topic=health&q=corona");
httReq2.send();
httReq2.onreadystatechange = function()
{
    if (httReq2.readyState == 4 && httReq2.status == 200)
    {
       allData2=JSON.parse(httReq2.response).articles;
       displayData2();
       displayData3();
    }
} 

function displayData2()
{
    var temp2 = ``;
    for(var i=0;i < allData2.length-2;i++ )
    {
        if (allData2[i].image==null)
        {
           allData2[i].image="images/4434735.jpg";
        }
        temp2 +=`<div class=carousel-item> <a href=`+allData2[i].url+` target=_blank> <img src=`+allData2[i].image+`> </a>  
        <div class="carousel-caption d-none d-md-block">
        <h5>`+ allData2[i].title+`</h5>
        <p>`+ allData2[i].description+`</p>
        </div>
        </div>`
    }
    document.getElementById("News1").innerHTML=temp2;
    $("#News1 .carousel-item").first().addClass("active");
}

function displayData3()
{
    var temp3 = ``;
    for(i=allData2.length-2;i<allData2.length;i++)
    {
        if (allData2[i].image==null)
        {
           allData2[i].image="images/4434735.jpg";
        }
       temp3 +=` 
       <div class="news2">
       <a href=`+allData2[i].url+` target=_blank>  <img src=`+allData2[i].image+`> </a>
      <a href=`+allData2[i].url+` target=_blank>  <p>`+allData2[i].description +`</p> </a> 
       </div>`
    }
    document.getElementById("News2").innerHTML=temp3;
}


       
/*nav*/
$(window).scroll(function(){
let wScroll = $(window).scrollTop();
if(wScroll>100)
{
$("#nav").css('background-color','#fff');
$("#nav .list ul li a").css('color','black');
$("#nav .line").css('background-color','#eee');
$(".login span").css('color','black');
$(".logo p").css('color','cyan');
$("#btnUp").fadeIn(500);
}
else
{
$("#nav").css('background-color','transparent');
$("#nav .line").css('background-color','rgba(255, 255, 255, 0.2)');
$("#nav .list ul li a").css('color','#fff');
$(".login span").css('color','#fff')
$(".logo p").css('color','#fff');
$("#btnUp").fadeOut(500);
}
});

/* button up */


$("#btnUp").click(function(){
$("html,body").animate({scrollTop:'0'},1000);
});


/* scroll a nav*/
$("a[href^='#']").click(function(){
    let href = $(this).attr("href");
    $("html,body").animate({scrollTop:$(href).offset().top-30},1000);

});

/* loading page */ 
$(document).ready(function(){

    $(".loading").fadeOut(2000,function(){
        
        $("body").css("overflow","auto");
        
    });
})
