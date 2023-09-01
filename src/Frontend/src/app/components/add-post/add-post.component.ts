import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent {
  
  constructor(private toastr: ToastrService) {}

  postText: string = '';
  selectedFile: File | null = null;

  onFileSelected(event: any) {
    const allowedTypes = ['image/jpeg', 'image/png', 'image/gif']; // List of allowed image MIME types

    const file: File = event.target.files[0];

    if (file && allowedTypes.includes(file.type)) {
      this.selectedFile = file;
    } else {
      // Display an error message or provide feedback to the user
     /* this.toastr.error('Invalid file type. Only JPEG, PNG, and GIF images are allowed.', 'Error' ,{
        toastClass: 'custom-toast-class', // Add your custom CSS class here
      });*/

      console.error('Invalid file type. Only JPEG, PNG, and GIF images are allowed.');
    }
  }

  sharePost() {
    // Here, you can handle the logic to send the post text and file to a server.
    // You can use services or APIs to perform the actual posting.
    if(this.postText != ""){
      console.log('Text:', this.postText);
      console.log('File:', this.selectedFile);
    } else {
      console.error('No post text!');
    }
  }
}
