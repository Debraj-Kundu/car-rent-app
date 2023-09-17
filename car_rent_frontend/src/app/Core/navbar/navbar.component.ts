import { Component, OnDestroy, OnInit } from '@angular/core';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit, OnDestroy {
  username!: string;

  isLoggedIn: boolean = false;
  userRole: string = '';

  constructor(
    private loginService: LoginService,
    private userStore: UserStoreService,
    private router: Router
  ) {}
  private subscription: Subscription = new Subscription();

  ngOnInit(): void {
    const nameFormToken = this.loginService.getFullNameFromToken();
    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.username = val || nameFormToken;
        this.isLoggedIn = this.loginService.isLoggedIn();
      })
    );
    const roleFormToken = this.loginService.getRoleFromToken();
    this.subscription.add(
      this.userStore.getRoleFormStore().subscribe((val) => {
        this.userRole = val || roleFormToken;
      })
    );
  }

  logout() {
    this.loginService.logout();
    this.isLoggedIn = false;
    this.router.navigate(['home']);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
