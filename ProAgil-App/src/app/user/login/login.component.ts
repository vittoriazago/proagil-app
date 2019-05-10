import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  titulo = 'login';
  model: any = {};

  constructor(private authService: AuthService,
              public router: Router,
              private toastr: ToastrService) {
}

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.router.navigate(['/dashboard']);
    }
  }

  login() {
    this.authService.login(this.model)
      .subscribe(() => {
        this.toastr.success('Logado com sucesso!');
        this.router.navigate(['/dashboard']);

      }, error => {
        this.toastr.error('Falha ao logar!');
      });
  }
}
