import { Component } from '@angular/core';
import {ActivatedRoute, RouterLink} from '@angular/router';
import {PasswordsService} from '../../../services/passwords/passwords.service';
import {Password} from '../../../models/password';
import {Application} from '../../../models/application';

@Component({
  selector: 'app-view-password',
  imports: [
    RouterLink
  ],
  templateUrl: './view-password.component.html',
  standalone: true,
  styleUrl: './view-password.component.css'
})
export class ViewPasswordComponent {
  constructor(
    private readonly passwordsService: PasswordsService,
    private route: ActivatedRoute
  ) {}

  password: Password = new Password(0, '', '', new Application(0, '', false));

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.passwordsService.getPasswordById(id).subscribe({
      next: (data) => {
        this.password = data;
        console.log(data);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
}
