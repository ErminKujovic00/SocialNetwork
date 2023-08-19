import { Component, OnInit, Input } from '@angular/core';

import { EmailSenderService } from 'src/app/services/emailSenderService/email-sender.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  name: string = "";
  subject: string = "";
  email: string = "";
  message: string = "";
  @Input() visibility: string;
  @Input() color: string;
  @Input() text: string;

  alertLabel = document.getElementById('alert');


  constructor(private emailSenderService: EmailSenderService){}

  ngOnInit(): void {
    
  }

  sendEmailClick(name: string, subject: string, email: string, message: string) : void{
    if(name === "" || subject  === "" || email  === "" || message  === ""){
      alert("Failure to send message! Empty fields.");
       return;
    }
    if(!email.includes("@")){
      alert("Email must contain symbol @");
      return;
    }
    
    this.emailSenderService.postEmail(name, subject, email, message).subscribe({
      next: (v) => {
        console.log(v)
      },
      error: (e) => {
        //console.log(e); 
        //alert("Failure");
        this.visibility = 'block';
        this.color = 'lightcoral';
        this.text = "Failure!";
      },
      complete: () => {
       // console.info('complete'); 
        //alert("Message has successfully been sent.");
        this.visibility = 'block';
        this.color = 'lightgreen';
        this.text = "Success!";
    }
    });

   /* this.emailSenderService.postEmail(name, subject, email, message).subscribe( response => {
      // Access the status code
      //console.log(response.status);
      if(response.status == 200){
        this.visibility = 'block';
        this.color = 'lightgreen';
        this.text = "Success!";
      } else {
        this.visibility = 'block';
        this.color = 'lightred';
        this.text = "Failure!";
      }
    });*/

    this.name = '';
    this.subject = '';
    this.email = '';
    this.message = '';

  }

}
