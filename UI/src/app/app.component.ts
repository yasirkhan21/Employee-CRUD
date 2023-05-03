import { Component,OnInit } from '@angular/core';
import { DataServiceService } from './data-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AngularDotNetAPICRUD';
  constructor(private data:DataServiceService){}
  empList:any=[];
  ngOnInit(): void {
   this.GetData();
  }


  GetData(){
    this.data.GetEmployees().subscribe(res=>{
      this.empList=res;
   });
   console.log(this.empList)
  }
}
