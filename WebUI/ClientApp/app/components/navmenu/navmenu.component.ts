import { Component, OnInit} from '@angular/core';
import { UserService } from '../../user/user.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {

    constructor(private userService: UserService) {
    }


    logout() {
        this.userService.logout();
    }

    
}
