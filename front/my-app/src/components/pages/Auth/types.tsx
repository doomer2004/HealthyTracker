export interface IUserData {
    firstName: string
    lastName: string
    email: string
    password: string
    confirmPassword: string
}

export interface ILoginData {
    email: string
    password: string
}

export interface IChangePasswordData {
    oldPassword: string
    newPassword: string
}