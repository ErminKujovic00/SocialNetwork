import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  trailArray = [
    {name: 'Kerim Softic', text: 'Hey, super je ovo!'},
    {name: 'Kerim Softic', text: 'Hey, super je ovo!'}
  ]
  cardDataArray = [
    {name: 'Ermin Kujovic', imgAccount: 'something', imgPost: 'something', text: 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Delectus facere cum unde ducimus ab, recusandae suscipit assumenda id aut officia, cumque dolore optio maiores illum nesciunt incidunt? Distinctio, id harum.'},
    {name: 'Ermin Kujovic', imgAccount: 'something', imgPost: 'something', text: 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Delectus facere cum unde ducimus ab, recusandae suscipit assumenda id aut officia, cumque dolore optio maiores illum nesciunt incidunt? Distinctio, id harum.'},
    {name: 'Ermin Kujovic', imgAccount: 'something', imgPost: 'something', text: 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Delectus facere cum unde ducimus ab, recusandae suscipit assumenda id aut officia, cumque dolore optio maiores illum nesciunt incidunt? Distinctio, id harum.'},
    {name: 'Ermin Kujovic', imgAccount: 'something', imgPost: 'something', text: 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Delectus facere cum unde ducimus ab, recusandae suscipit assumenda id aut officia, cumque dolore optio maiores illum nesciunt incidunt? Distinctio, id harum.'}
  ]
}
