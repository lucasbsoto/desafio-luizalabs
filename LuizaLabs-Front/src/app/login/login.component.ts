import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../shared/services/user.service';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  formLogin = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(private userService: UserService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {

  }

  public login(){
    
    if(this.formLogin.get('email')?.valid && this.formLogin.get('password')?.valid){
      let email = this.formLogin.get('email')?.value;
      let password = this.formLogin.get('password')?.value; 

      this.userService.PostAuthenticate({Email: email, Password: password})
          .pipe(catchError(error => 
            { 
              this.toastr.show(error); 
              return Promise.resolve() 
            }))
          .subscribe(response => {

            localStorage.setItem('usuario', JSON.stringify(response));
            this.router.navigate(['home']);
          });
    }
  }
}
