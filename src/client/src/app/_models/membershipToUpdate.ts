
export interface MembershipToUpdate {
    id: number;
    start: Date;
    end: Date;
    membershipTypeId: number;
    membershipSizeId: number;
    online: boolean;
    isActive: boolean;  
}