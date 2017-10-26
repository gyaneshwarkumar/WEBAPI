export interface User {
    token?;
    expiration?;
    claims: IClaim[];
    id?;
    userName?;
    email?;
    currentUser: IUser;
}

interface IClaim {
    type: string;
    value: string;
}

interface IUser {
    id: string;
    userName: string;
    email: string;
}