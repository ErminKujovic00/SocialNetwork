import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-post-card',
  templateUrl: './post-card.component.html',
  styleUrls: ['./post-card.component.css']
})
export class PostCardComponent {
  @Input() cardData: {
    //commentsArray: {name: string, text: string},
    name: string
    imgAccount: string,
    imgPost: string,
    text: string
  };

  commentDataArray = [
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', img: 'somthing', text: 'Hey, super je ovo!'}
  ]
}
