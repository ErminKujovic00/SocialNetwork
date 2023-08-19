import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  constructor(){}

  fullname: string = "";
  username: string = "";
  email: string = "";
  pswd: string = "";
  pswdReenter: string = "";



  ngOnInit(): void {}

  dataValidator(fullname: string, username: string, email: string, pswd: string, pswdReenter: string) : boolean{
    if(fullname === "" || username  === "" || email  === "" || pswd  === "" || pswdReenter  === "") return false;
    return true;
  }

  apiSignUpCall(fullname: string, username: string, email: string, pswd: string, pswdReenter: string){
    if(this.dataValidator(fullname, username, email, pswd, pswdReenter)){
      alert("Failure to signup! Empty fields."); return;
    }
    if(pswd != pswdReenter) {
      alert("Failure to signup! Passwords do not match!"); return;
    }
    console.log("SignUp");
  }

  apiLoginCall(){
    console.log("Login");
  }

}
