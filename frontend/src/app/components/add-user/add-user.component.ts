import { Component } from '@angular/core';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css'],
})
export class AddUserComponent {
  user: User = {
    title: '',
    description: '',
    published: false
  };
  submitted = false;

  constructor(private userService: UserService) {}

  saveUser(): void {
    const data = {
      title: this.user.title,
      description: this.user.description
    };

    this.userService.create(data).subscribe({
      next: (res) => {
        console.log(res);
        this.submitted = true;
      },
      error: (e) => console.error(e)
    });
  }

  newUser(): void {
    this.submitted = false;
    this.user = {
      title: '',
      description: '',
      published: false
    };
  }
}
