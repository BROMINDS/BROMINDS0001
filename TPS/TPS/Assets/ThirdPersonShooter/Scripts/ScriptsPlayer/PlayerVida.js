#pragma strict

//VARIABLE PUBLICA
var Vida : int;

//VARIABLE PRIVADA
private var A : Animator;

function Start (){
//A = al componente Animator que hay en este objeto
A = GetComponent.<Animator>();
}

function Update () {

//Si la vida es menor o igual a 0
if(Vida <= 0){
A.SetBool("muerte", true);//activamos la animacion de muerte
}
}