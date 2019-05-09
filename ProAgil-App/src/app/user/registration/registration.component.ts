import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;

  constructor(public fb: FormBuilder,
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

  }
}
