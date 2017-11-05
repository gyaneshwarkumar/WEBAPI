import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../../user/user.profile';


@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {


    public demo: boolean;

    constructor(private authProfile: UserProfile) {
    }

   
    //ngOnInit() {
    //    debugger;
    //    this.demo = this.authProfile.isLoggedIn;

    //    return this.demo;
    //}
    showElement() {
        this.demo = this.authProfile.isLoggedIn;

        return this.demo;
    }
}
