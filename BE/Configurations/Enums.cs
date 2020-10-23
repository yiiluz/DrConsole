using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Configurations
{
    public enum Gender
    {
        MALE,
        FEMALE
    }

    public enum Expertise
    {
        FAMILY,
        CHILDRENS,
        SKIN,
        EYES,
        SURGEON,
        ORTHOPEDICS
    }

    public enum UserType
    {
        DOCTOR,
        ADMIN,
        PATIENT
    }
}
