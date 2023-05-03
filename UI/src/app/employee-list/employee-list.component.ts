import { Component, OnInit } from '@angular/core';
import { employee } from 'src/models/employee';
import { DataServiceService } from '../data-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  constructor(private dataservice: DataServiceService, public formbuilder: FormBuilder,public toast:ToastrService) {
    //this.featchEmp();
   }
  empList!: employee[];
  empForm!: FormGroup;
  addempForm!:FormGroup;
  ngOnInit(): void {
    this.featchEmp();
    this.empForm = this.formbuilder.group({
      empNo: ['', [Validators.required]],
      name: ['', [Validators.required]],
      basic: ['', [Validators.required]],
      deptNo: ['', [Validators.required]]
    });
    this.addempForm = this.formbuilder.group({
      empNo: ['', [Validators.required]],
      name: ['', [Validators.required]],
      basic: ['', [Validators.required]],
      deptNo: ['', [Validators.required]]
    });


  }

  deleteEmp(id: number) {
    this.dataservice.deleteEmp(id).subscribe(res => {
     this.toast.success("Employee Deleted ")
      this.featchEmp();
    },err=>{
      this.toast.error(err.error.ErrorMessage || "Something went wrong") 
    });

  }

  edit(emp: employee) {
    const data: employee = {
      empNo: emp.empNo,
      name: emp.name,
      basic: emp.basic,
      deptNo: emp.deptNo
    }
    console.log(emp)
    this.empForm.setValue(data)
  }
  editEmp(emp: employee) {
    this.dataservice.editEmp(emp.empNo, emp).subscribe(res => {
      this.empForm.reset();
      this.toast.success("Employee updated ")
      this.featchEmp();
    },err=>{
      this.toast.error(err.error.ErrorMessage || "Something went wrong")
      this.empForm.reset();
    })
  }

  public featchEmp() {
    this.dataservice.GetEmployees().subscribe(res => {
      this.empList = res;
      console.log(this.empList)
    }, err => {
      this.toast.error(err.error.ErrorMessage || "Something went wrong")
    })
  }
  addEmp(){
  
     if(this.addempForm.valid){
      this.dataservice.postEmployee(this.addempForm.value).subscribe(res=>{
        this.featchEmp();
       this.toast.success("Employee Added Successfully")
        this.addempForm.reset();
        console.log("Addcomp"+res)
        //window.location.reload();
      },err=>{
        this.toast.error(err.error.ErrorMessage || "Something went wrong")
        this.addempForm.reset();
      });
      
     }
     else{
        this.toast.error("Enter valid data");
     }
    }
  
}
