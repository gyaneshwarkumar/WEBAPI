import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Headers } from '@angular/http';
import { User } from './index'

@Injectable()
export class UserProfile {
    userProfile: User = {
        token: "",
        expiration: "",
        id: "",
        userName: "",
        email: "",
        claims: [],
        currentUser: { id: '', userName: '', email: '' }
    };


    constructor(private router: Router) {
    }

    setProfile(profile: User): void {
         var nameid = profile.claims.filter(p => p.type == 'nameid')[0].value;
        var userName = profile.claims.filter(p => p.type == 'sub')[0].value;
        var email = profile.claims.filter(p => p.type == 'email')[0].value;
        sessionStorage.setItem('access_token', profile.token);
        sessionStorage.setItem('expires_in', profile.expiration);
        sessionStorage.setItem('nameid', nameid);
        sessionStorage.setItem('userName', userName);
        sessionStorage.setItem('email', email);
    }

    getProfile(authorizationOnly: boolean = false): User {
        var accessToken = sessionStorage.getItem('access_token');

        if (accessToken) {
            this.userProfile.token = accessToken;
            this.userProfile.expiration = sessionStorage.getItem('expires_in');
            if (this.userProfile.token == null) {
                this.userProfile.currentUser = { id: '', userName: '', email: '' }
            }
            this.userProfile.id = sessionStorage.getItem('nameid');
            this.userProfile.userName = sessionStorage.getItem('userName');
        }

        return this.userProfile;
    }

    resetProfile(): User {
        sessionStorage.removeItem('access_token');
        sessionStorage.removeItem('expires_in');
        this.userProfile = {
            token: "",
            expiration: "",
            currentUser: { id: '', userName: '', email: '' },
            claims: []
        };
        return this.userProfile;
    }
}