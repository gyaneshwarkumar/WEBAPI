import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Signup } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";
import { CommonService } from '../../shared/common.service'
import { UserService } from '../user/user.service';
import { Router } from '@angular/router';
import { User } from '../user/user.model';
import { UserProfile } from '../user/user.profile';

@Injectable()
export class LoginService {

  //  private _getBatchUrl = "/Batch/GetContacts";
    public url = this.commonService.getBaseAuthUrl() + '/auth/token';
   
    constructor(private http: Http, private commonService: CommonService, private authService: UserService, private authProfile: UserProfile,
        private router: Router) { }
 
    login(signup: Signup): Observable<string> {
        var credentials = {
            grant_type: 'password',
            email: signup.email,
            password: signup.password
        };
       //let body = JSON.stringify(signup);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.url, credentials, options)
            //.map(res => res.json().message)
            //.catch(this.handleError);
            .map((response: Response) => {
                var userProfile: User = response.json();
                this.authProfile.setProfile(userProfile);
                return response.json();
            }).catch(this.commonService.handleFullError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }


}