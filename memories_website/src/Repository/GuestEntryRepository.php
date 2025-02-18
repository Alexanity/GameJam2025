<?php

namespace App\Repository;

use App\Entity\GuestEntry;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\ORM\Query;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @extends ServiceEntityRepository<GuestEntry>
 */
class GuestEntryRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, GuestEntry::class);
    }

    public function save(GuestEntry $guestEntry, bool $isFlush = true): void
    {
        $this->getEntityManager()->persist($guestEntry);

        if ($isFlush) {
            $this->getEntityManager()->flush();
        }
    }

    public function getEntries(bool $isAscending): Query
    {
        $qb = $this->createQueryBuilder('ge')
            ->orderBy('ge.id', $isAscending ? 'ASC' : 'DESC');

        return $qb->getQuery();
    }
}
