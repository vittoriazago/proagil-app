import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/User';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  user: User;

  constructor(private authService: AuthService,
              public router: Router,
              public fb: FormBuilder,
              private toastr: ToastrService) {
  }
  ngOnInit() {
  }
  validation() {
      this.registerForm = this.fb.group({
        fullname : ['', Validators.required],
        email : ['', [Validators.required, Validators.email]],
        username : ['', Validators.required],
        passwords: this.fb.group({
          password : ['', [Validators.required, Validators.minLength(4)]],
          confirmPassword : ['', Validators.required],
        }, { validators : this.compararSenhas })
      });
  }
  compararSenhas(fb: FormGroup) {
    const confirmSenhaCtrl = fb.get('confirmPassword');
    if (confirmSenhaCtrl.errors == null
      || 'mismatch' in confirmSenhaCtrl.errors) {
        if (fb.get('password').value !== confirmSenhaCtrl.value) {
          confirmSenhaCtrl.setErrors({ mismatch: true });
        } else {
          confirmSenhaCtrl.setErrors(null);
        }
      }
  }
  cadastrarUsuario() {
    if (this.registerForm.valid) {
      this.user = Object.assign({
        password: this.registerForm.get('passwords.password').value
      }, this.registerForm.value);
      this.authService.register(this.user)
      .subscribe(() => {
        this.router.navigate(['user/login']);
        this.toastr.success('Inserido com sucesso!');
      }, error => {
        const erro = error.error;
        erro.forEach(element => {
          switch (element.code) {
            case 'DuplicateUserName':
            this.toastr.error('Cadastro Duplicado!');
            break;
            default:
            this.toastr.error(`Erro no Cadatro! CODE: ${element.code}`);
            break;
          }
        });
      }
      );
    }
  }
}
