import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { employee } from 'src/models/employee';
@Injectable({
  providedIn: 'root'
})
export class DataServiceService {

  constructor(private http: HttpClient) { }

  public url = 'http://localhost:5033/api/'
  GetEmployees(): Observable<employee[]> {
    return this.http.get<employee[]>(this.url + 'Employees')
  }

  postEmployee(emp: employee) {
    return this.http.post<employee>(this.url + 'Employees', emp)
  }

  deleteEmp(id:number){
    return this.http.delete(this.url+'Employees/'+id)
  }
editEmp(id:number,emp:employee){
  return this.http.put(this.url+'Employees/'+id,emp)
}

}
