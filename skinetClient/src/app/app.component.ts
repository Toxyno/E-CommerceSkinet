import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  implements OnInit{
  
  title = 'skinetClient';

    //We can out Http API but before then, we need to Inject the dependencies in the constructor
  constructor(private http:HttpClient){}
  
  //creating a property to hold our response
  products: any[];

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/products?pageSize=50').subscribe((response: any) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }
}
