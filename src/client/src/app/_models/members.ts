import { Membership } from "./membership";

export interface Member {
    id: number;
    fullName: string;
    birthday: Date;
    phoneNumber: string;
    email: string;
    comment: string;
    memberships: Membership[];
}