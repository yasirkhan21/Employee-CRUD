import { Component,OnInit } from '@angular/core';
import { employee } from 'src/models/employee';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { DataServiceService } from '../data-service.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
empForm!:FormGroup;
empList!: employee[];

constructor(private datasrv:DataServiceService,public formbuilder:FormBuilder,public toast:ToastrService){
 
}

  ngOnInit(): void {
  this.empForm=this.formbuilder.group({
    empNo:['',[Validators.required]],
    name:['',[Validators.required]],
    basic:['',[Validators.required]],
    deptno:['',[Validators.required]]
  });
   this.featchEmp();
  }
  addEmp(){
// let emplist = new EmployeeListComponent(this.datasrv,this.formbuilder,this.toast);
 if(this.empForm.valid){
  this.datasrv.postEmployee(this.empForm.value).subscribe(res=>{
   this.toast.success("Employee Added Successfully")
    this.empForm.reset();
    console.log("Addcomp"+res)
    //window.location.reload();
  },err=>{
    this.toast.error(err.error.ErrorMessage)
  });
  
 }
 else{
    this.toast.error("Enter valid data");
 }
}

featchEmp() {

  this.datasrv.GetEmployees().subscribe(res => {
    this.empList = res;
    console.log(this.empList)
  }, err => {
    this.toast.error(err.error.ErrorMessage)
  })
}
}
