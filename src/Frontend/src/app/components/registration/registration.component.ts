import { Component, OnInit } from '@angular/core';
import { SignUpService } from 'src/app/services/signUpService/sign-up-service.service';
import axios, { AxiosError, AxiosResponse } from 'axios';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  constructor(private _signUpService: SignUpService){}

  url = 'https://localhost:7297/api/Users';
  
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

  separateFullName(fullName: string): [string, string] {
    let firstName = "";
    let lastName = "";

    if (fullName && fullName.trim() !== "") {
        const nameParts = fullName.trim().split(' ');

        if (nameParts.length > 0) {
            firstName = nameParts[0];
        }

        if (nameParts.length > 1) {
            lastName = nameParts.slice(1).join(' '); // Combine remaining parts as the last name
        }
    }

    return [firstName, lastName];
  }

  isStrongPassword(password: string): boolean {
    // Define regular expressions to check for numbers, letters, and special characters
    const hasNumber = /\d/.test(password);
    const hasLetter = /[a-zA-Z]/.test(password);
    const hasSpecialChar = /[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]/.test(password);
  
    // Check if the password meets all the criteria
    const isLongEnough = password.length > 6;
  
    return hasNumber && hasLetter && hasSpecialChar && isLongEnough;
  }

  apiSignUpCall(fullname: string, username: string, email: string, pswd: string, pswdReenter: string){
    if(this.dataValidator(fullname, username, email, pswd, pswdReenter) == false){
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failure to signup! Empty fields.',
       // footer: '<a href="">Why do I have this issue?</a>'
      });
      return;
      //alert("Failure to signup! Empty fields."); return;
    }
    if(this.isStrongPassword(pswd) == false){
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Password must contain letters, numbers, special characters and be longer than six characters.',
       // footer: '<a href="">Why do I have this issue?</a>'
      });
      return;
      //alert("Password must contain letters, numbers, special characters and be longer than six characters."); return;
    }
    if(pswd != pswdReenter) {
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failure to signup! Passwords do not match!',
       // footer: '<a href="">Why do I have this issue?</a>'
      });
      return;
      //alert("Failure to signup! Passwords do not match!"); return;
    }

    const [firstName, lastName] = this.separateFullName(fullname);

   /* this._signUpService.signUpUser(firstName, lastName, username, email, pswd).subscribe({
      next: (v) => {
        console.log(v)
      },
      error: (e) => {
        console.log("Sign up failure!");
      },
      complete: () =>{
        console.log("Sign up completed!");
      }
    });*/

    this._signUpService.signUpUser(firstName, lastName, username, email, pswd)
    .then((response: AxiosResponse) => {
      //ovdje da se doda alert i da se podigne login za dalje
      Swal.fire('Uspjeh!');
      console.log("Sign up completed!");
      //console.log("Response data:", response.data);
    })
    .catch((error: AxiosError) => {
      //dodaj alert za gresku
      Swal.fire({
        icon: 'error',
        title: 'Failure',
        text: 'Something went wrong!',
        footer: '<a href="">Why do I have this issue?</a>'
      })
      //console.error("Error:", error);
    });

    this.fullname = '';
    this.username = '';
    this.email = '';
    this.pswd = '';
    this.pswdReenter = '';

  }

  apiLoginCall(){
    console.log("Login");
  }

}
