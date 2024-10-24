import { Component } from '@angular/core';
import { FormGroup, FormControl, } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  profileForm = new FormGroup({
    name: new FormControl('',),
    email: new FormControl(''),
  });
  onSubmit() {
    console.log(this.profileForm.value);
  }
}
