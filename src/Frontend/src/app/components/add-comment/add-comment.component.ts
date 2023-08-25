import { Component } from '@angular/core';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent {
  newComment = {
    name: 'Ermin',
    commentText: ''
  };

  submitComment(){
    console.log(this.newComment.name + ' ' + this.newComment.commentText);
    
    // Reset the form after submission
    this.newComment = {
      name: 'Ermin',
      commentText: ''
    };
  }
}
