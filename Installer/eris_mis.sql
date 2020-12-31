-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 20, 2020 at 02:49 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eris_mis`
--

-- --------------------------------------------------------

--
-- Table structure for table `archive_class`
--

CREATE TABLE `archive_class` (
  `archive_class_id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `school_year` int(11) NOT NULL,
  `teacher_adviser` int(11) NOT NULL,
  `room_id` int(11) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `update_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL,
  `level_section_id` int(11) NOT NULL,
  `archived_date` varchar(32) NOT NULL,
  `archived_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_delete_transaction`
--

CREATE TABLE `archive_delete_transaction` (
  `archived_delete_id` int(11) NOT NULL,
  `delete_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL,
  `archived_date` varchar(32) NOT NULL,
  `archived_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_grading`
--

CREATE TABLE `archive_grading` (
  `archive_grading_id` int(11) NOT NULL,
  `grade_id` int(11) NOT NULL,
  `school_year` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `student_grade` int(11) NOT NULL,
  `student_status` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `grading_period` int(11) NOT NULL,
  `encoded_date` int(11) NOT NULL,
  `encoded_by` int(11) NOT NULL,
  `updated_date` int(11) NOT NULL,
  `updated_by` int(11) NOT NULL,
  `deleted_date` int(11) NOT NULL,
  `deleted_by` int(11) NOT NULL,
  `archive_date` int(11) NOT NULL,
  `archive_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_graduated_students`
--

CREATE TABLE `archive_graduated_students` (
  `archive_graduated__id` int(11) NOT NULL,
  `student_no` int(11) NOT NULL,
  `file_status` int(11) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `middle_name` varchar(32) NOT NULL,
  `city_address` varchar(32) NOT NULL,
  `date_of_birth` varchar(32) NOT NULL,
  `sex` varchar(32) NOT NULL,
  `guardian_id` int(11) NOT NULL,
  `school_history_id` int(11) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL,
  `archived_date` varchar(32) NOT NULL,
  `archived_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_guardian_info`
--

CREATE TABLE `archive_guardian_info` (
  `guardian_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `relationship` int(11) NOT NULL,
  `occupation` varchar(32) NOT NULL,
  `contact` varchar(32) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL,
  `archived_date` varchar(32) NOT NULL,
  `archived_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_schedule`
--

CREATE TABLE `archive_schedule` (
  `archive_schedule_id` int(11) NOT NULL,
  `time_sched_id` int(11) NOT NULL,
  `school_year` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `time_id` int(11) NOT NULL,
  `day_id` int(11) NOT NULL,
  `assignment_id` int(11) NOT NULL,
  `created_date` int(11) NOT NULL,
  `created_by` int(11) NOT NULL,
  `updated_date` int(11) NOT NULL,
  `updated_by` int(11) NOT NULL,
  `archived_date` int(11) NOT NULL,
  `archived_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_school_history`
--

CREATE TABLE `archive_school_history` (
  `history` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `school_name` varchar(32) NOT NULL,
  `school_level` varchar(32) NOT NULL,
  `year_entry` int(11) NOT NULL,
  `year_exit` int(11) NOT NULL,
  `address` varchar(32) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL,
  `archived_date` varchar(32) NOT NULL,
  `archived_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `archive_update_transaction`
--

CREATE TABLE `archive_update_transaction` (
  `archive_update_id` int(11) NOT NULL,
  `school_year` int(11) NOT NULL,
  `update_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  `updated_field` varchar(32) NOT NULL,
  `old_data` varchar(32) NOT NULL,
  `new_data` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `archived_date` varchar(32) NOT NULL,
  `archived_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_barangay`
--

CREATE TABLE `table_barangay` (
  `barangay_id` int(11) NOT NULL,
  `zip_id` int(11) NOT NULL,
  `barangay_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `table_barangay`
--

INSERT INTO `table_barangay` (`barangay_id`, `zip_id`, `barangay_name`) VALUES
(1, 21, 'Addition Hills'),
(2, 21, 'Bagong Silang'),
(3, 21, 'Barangka Drive'),
(4, 21, 'Barangka Ibaba'),
(5, 21, 'Barangka Ilaya'),
(6, 21, 'Barangka Itaas'),
(7, 21, 'Buayang Bato'),
(8, 21, 'Burol'),
(9, 21, 'Daang Bakal'),
(10, 21, 'Hagdang Bato Itaas'),
(11, 21, 'Hagdang Bato Libis'),
(12, 21, 'Harapin Ang Bukas'),
(13, 21, 'Highway Hills'),
(14, 21, 'Hulo'),
(15, 21, 'Mabini-J. Rizal'),
(16, 21, 'Malamig'),
(17, 21, 'Mauway'),
(18, 21, 'Namayan'),
(19, 21, 'New Zañiga'),
(20, 21, 'Old Zañiga'),
(21, 21, 'Pag-asa'),
(22, 21, 'Plainview'),
(23, 21, 'Pleasant Hills'),
(24, 21, 'Poblacion'),
(25, 21, 'San Jose'),
(26, 24, 'Vergara'),
(27, 21, 'Wack-Wack Greenhills'),
(28, 19, 'East Edsa'),
(29, 20, 'Greenhills South'),
(30, 22, 'National Center for Mental Health'),
(31, 23, 'Shaw Boluevard'),
(32, 25, 'Wack Wack'),
(33, 1, 'Barangay 287 '),
(34, 1, 'Barangay 288 '),
(35, 1, 'Barangay 289 '),
(36, 1, 'Barangay 290 '),
(37, 1, 'Barangay 291 '),
(38, 1, 'Barangay 292 '),
(39, 1, 'Barangay 293 '),
(40, 1, 'Barangay 294 '),
(41, 1, 'Barangay 295 '),
(42, 1, 'Barangay 296 '),
(43, 26, 'Barangay 659 '),
(44, 26, 'Barangay 659 - A'),
(45, 26, 'Barangay 660 '),
(46, 26, 'Barangay 660 - A'),
(47, 26, 'Barangay 661 '),
(48, 26, 'Barangay 663 '),
(49, 26, 'Barangay 663 - A'),
(50, 26, 'Barangay 664 '),
(51, 26, 'Barangay 665 '),
(52, 26, 'Barangay 666 '),
(53, 26, 'Barangay 667 '),
(54, 26, 'Barangay 668 '),
(55, 26, 'Barangay 669 '),
(56, 26, 'Barangay 670 '),
(57, 2, 'Barangay 654 '),
(58, 2, 'Barangay 655 '),
(59, 2, 'Barangay 656 '),
(60, 2, 'Barangay 657 '),
(61, 2, 'Barangay 658 '),
(62, 3, 'Barangay 688 '),
(63, 3, 'Barangay 689 '),
(64, 3, 'Barangay 690 '),
(65, 3, 'Barangay 691 '),
(66, 3, 'Barangay 692 '),
(67, 3, 'Barangay 693 '),
(68, 3, 'Barangay 694 '),
(69, 3, 'Barangay 695 '),
(70, 3, 'Barangay 696 '),
(71, 3, 'Barangay 697 '),
(72, 3, 'Barangay 698 '),
(73, 3, 'Barangay 699 '),
(74, 3, 'Barangay 700 '),
(75, 3, 'Barangay 701 '),
(76, 3, 'Barangay 702 '),
(77, 3, 'Barangay 703 '),
(78, 3, 'Barangay 704 '),
(79, 3, 'Barangay 705 '),
(80, 3, 'Barangay 706 '),
(81, 3, 'Barangay 707 '),
(82, 3, 'Barangay 708 '),
(83, 3, 'Barangay 709 '),
(84, 3, 'Barangay 710 '),
(85, 3, 'Barangay 711 '),
(86, 3, 'Barangay 712 '),
(87, 3, 'Barangay 713 '),
(88, 3, 'Barangay 714 '),
(89, 3, 'Barangay 715 '),
(90, 3, 'Barangay 716 '),
(91, 3, 'Barangay 717 '),
(92, 3, 'Barangay 718 '),
(93, 3, 'Barangay 719 '),
(94, 3, 'Barangay 720 '),
(95, 3, 'Barangay 721 '),
(96, 3, 'Barangay 722 '),
(97, 3, 'Barangay 723 '),
(98, 3, 'Barangay 724 '),
(99, 3, 'Barangay 725 '),
(100, 3, 'Barangay 726 '),
(101, 3, 'Barangay 727 '),
(102, 3, 'Barangay 728 '),
(103, 3, 'Barangay 729 '),
(104, 3, 'Barangay 730 '),
(105, 3, 'Barangay 731 '),
(106, 3, 'Barangay 732 '),
(107, 3, 'Barangay 733 '),
(108, 3, 'Barangay 734 '),
(109, 3, 'Barangay 735 '),
(110, 3, 'Barangay 736 '),
(111, 3, 'Barangay 737 '),
(112, 3, 'Barangay 738 '),
(113, 3, 'Barangay 739 '),
(114, 3, 'Barangay 740 '),
(115, 3, 'Barangay 741 '),
(116, 3, 'Barangay 742 '),
(117, 3, 'Barangay 743 '),
(118, 3, 'Barangay 744 '),
(119, 4, 'Barangay 662'),
(120, 4, 'Barangay 664 - A'),
(121, 4, 'Barangay 671 '),
(122, 4, 'Barangay 672 '),
(123, 4, 'Barangay 673 '),
(124, 4, 'Barangay 674 '),
(125, 4, 'Barangay 675 '),
(126, 4, 'Barangay 676 '),
(127, 4, 'Barangay 677 '),
(128, 4, 'Barangay 678 '),
(129, 4, 'Barangay 679 '),
(130, 4, 'Barangay 680 '),
(131, 4, 'Barangay 681 '),
(132, 4, 'Barangay 682 '),
(133, 4, 'Barangay 683 '),
(134, 4, 'Barangay 684 '),
(135, 4, 'Barangay 685 '),
(136, 4, 'Barangay 686 '),
(137, 4, 'Barangay 687 '),
(140, 4, 'Barangay 809 '),
(141, 4, 'Barangay 810 '),
(142, 4, 'Barangay 811 '),
(143, 4, 'Barangay 812 '),
(144, 4, 'Barangay 813 '),
(145, 4, 'Barangay 813 '),
(146, 4, 'Barangay 814 '),
(147, 4, 'Barangay 815 '),
(148, 4, 'Barangay 816 '),
(149, 4, 'Barangay 817 '),
(150, 4, 'Barangay 818 '),
(151, 4, 'Barangay 819 '),
(152, 4, 'Barangay 820 '),
(153, 4, 'Barangay 821 '),
(154, 4, 'Barangay 822 '),
(155, 4, 'Barangay 823 '),
(156, 4, 'Barangay 824 '),
(157, 4, 'Barangay 825 '),
(158, 4, 'Barangay 826 '),
(159, 4, 'Barangay 827 '),
(160, 4, 'Barangay 828 '),
(161, 4, 'Barangay 829 '),
(162, 4, 'Barangay 830 '),
(163, 4, 'Barangay 831 '),
(164, 4, 'Barangay 832 '),
(165, 5, 'Barangay 833 '),
(166, 5, 'Barangay 834 '),
(167, 5, 'Barangay 835 '),
(168, 5, 'Barangay 836 '),
(169, 5, 'Barangay 837 '),
(170, 5, 'Barangay 838 '),
(171, 5, 'Barangay 839 '),
(172, 5, 'Barangay 840 '),
(173, 5, 'Barangay 841 '),
(174, 5, 'Barangay 842 '),
(175, 5, 'Barangay 843 '),
(176, 5, 'Barangay 844 '),
(177, 5, 'Barangay 845 '),
(178, 5, 'Barangay 846 '),
(179, 5, 'Barangay 847 '),
(180, 5, 'Barangay 848 '),
(181, 5, 'Barangay 849 '),
(182, 5, 'Barangay 850 '),
(183, 5, 'Barangay 851 '),
(184, 5, 'Barangay 852 '),
(185, 5, 'Barangay 853 '),
(186, 5, 'Barangay 855 '),
(187, 5, 'Barangay 856 '),
(188, 5, 'Barangay 857 '),
(189, 5, 'Barangay 858 '),
(190, 5, 'Barangay 859 '),
(191, 5, 'Barangay 860 '),
(192, 5, 'Barangay 861 '),
(193, 5, 'Barangay 862 '),
(194, 5, 'Barangay 863 '),
(195, 5, 'Barangay 864 '),
(196, 5, 'Barangay 865 '),
(197, 5, 'Barangay 867 '),
(198, 5, 'Barangay 868 '),
(199, 5, 'Barangay 869 '),
(200, 5, 'Barangay 870 '),
(201, 5, 'Barangay 871 '),
(202, 5, 'Barangay 872 '),
(203, 6, 'Barangay 849 '),
(204, 6, 'Barangay 850 '),
(205, 6, 'Barangay 851 '),
(206, 6, 'Barangay 852 '),
(207, 6, 'Barangay 853 '),
(208, 7, 'Barangay 306 '),
(209, 7, 'Barangay 307 '),
(210, 7, 'Barangay 308 '),
(211, 7, 'Barangay 309 '),
(212, 7, 'Barangay 383 '),
(213, 7, 'Barangay 384 '),
(214, 7, 'Barangay 385 '),
(215, 7, 'Barangay 386 '),
(216, 7, 'Barangay 387 '),
(217, 7, 'Barangay 388 '),
(218, 7, 'Barangay 389 '),
(219, 7, 'Barangay 390 '),
(220, 7, 'Barangay 391 '),
(221, 7, 'Barangay 392 '),
(222, 7, 'Barangay 393 '),
(223, 7, 'Barangay 394 '),
(224, 8, 'Barangay 395 '),
(225, 8, 'Barangay 396 '),
(226, 8, 'Barangay 397 '),
(227, 8, 'Barangay 398 '),
(228, 8, 'Barangay 399 '),
(229, 8, 'Barangay 400 '),
(230, 8, 'Barangay 401 '),
(231, 8, 'Barangay 402 '),
(232, 8, 'Barangay 403 '),
(233, 8, 'Barangay 404 '),
(234, 8, 'Barangay 405 '),
(235, 8, 'Barangay 406 '),
(236, 8, 'Barangay 407 '),
(237, 8, 'Barangay 408 '),
(238, 8, 'Barangay 409 '),
(239, 8, 'Barangay 410 '),
(240, 8, 'Barangay 411 '),
(241, 8, 'Barangay 412 '),
(242, 8, 'Barangay 413 '),
(243, 8, 'Barangay 414 '),
(244, 8, 'Barangay 415 '),
(245, 8, 'Barangay 416 '),
(246, 8, 'Barangay 417 '),
(247, 8, 'Barangay 418 '),
(248, 8, 'Barangay 419 '),
(249, 8, 'Barangay 420 '),
(250, 8, 'Barangay 421 '),
(251, 8, 'Barangay 422 '),
(252, 8, 'Barangay 423 '),
(253, 8, 'Barangay 424 '),
(254, 8, 'Barangay 425 '),
(255, 8, 'Barangay 426 '),
(256, 8, 'Barangay 427 '),
(257, 8, 'Barangay 428 '),
(258, 8, 'Barangay 429 '),
(259, 8, 'Barangay 430 '),
(260, 8, 'Barangay 431 '),
(261, 8, 'Barangay 432 '),
(262, 8, 'Barangay 433 '),
(263, 8, 'Barangay 434 '),
(264, 8, 'Barangay 435 '),
(265, 8, 'Barangay 436 '),
(266, 8, 'Barangay 437 '),
(267, 8, 'Barangay 438 '),
(268, 8, 'Barangay 439 '),
(269, 8, 'Barangay 440 '),
(270, 8, 'Barangay 441 '),
(271, 8, 'Barangay 442 '),
(272, 8, 'Barangay 443 '),
(273, 8, 'Barangay 444 '),
(274, 8, 'Barangay 445 '),
(275, 8, 'Barangay 446 '),
(276, 8, 'Barangay 447 '),
(277, 8, 'Barangay 448 '),
(278, 8, 'Barangay 449 '),
(279, 8, 'Barangay 450 '),
(280, 8, 'Barangay 451 '),
(281, 8, 'Barangay 452 '),
(282, 8, 'Barangay 453 '),
(283, 8, 'Barangay 454 '),
(284, 8, 'Barangay 455 '),
(285, 8, 'Barangay 456 '),
(286, 8, 'Barangay 457 '),
(287, 8, 'Barangay 458 '),
(288, 8, 'Barangay 459 '),
(289, 8, 'Barangay 460 '),
(290, 8, 'Barangay 461 '),
(291, 8, 'Barangay 462 '),
(292, 8, 'Barangay 463 '),
(293, 8, 'Barangay 464 '),
(294, 8, 'Barangay 465 '),
(295, 8, 'Barangay 466 '),
(296, 8, 'Barangay 467 '),
(297, 8, 'Barangay 468 '),
(298, 8, 'Barangay 469 '),
(299, 8, 'Barangay 470 '),
(300, 8, 'Barangay 471 '),
(301, 8, 'Barangay 472 '),
(302, 8, 'Barangay 473 '),
(303, 8, 'Barangay 474 '),
(304, 8, 'Barangay 475 '),
(305, 8, 'Barangay 476 '),
(306, 8, 'Barangay 477 '),
(307, 8, 'Barangay 478 '),
(308, 8, 'Barangay 479 '),
(309, 8, 'Barangay 480 '),
(310, 8, 'Barangay 481 '),
(311, 8, 'Barangay 482 '),
(312, 8, 'Barangay 483 '),
(313, 8, 'Barangay 484 '),
(314, 8, 'Barangay 485 '),
(315, 8, 'Barangay 486 '),
(316, 8, 'Barangay 487 '),
(317, 8, 'Barangay 488 '),
(318, 8, 'Barangay 489 '),
(319, 8, 'Barangay 490 '),
(320, 8, 'Barangay 491 '),
(321, 8, 'Barangay 492 '),
(322, 8, 'Barangay 493 '),
(323, 8, 'Barangay 494 '),
(324, 8, 'Barangay 495 '),
(325, 8, 'Barangay 496 '),
(326, 8, 'Barangay 497 '),
(327, 8, 'Barangay 498 '),
(328, 8, 'Barangay 499 '),
(329, 8, 'Barangay 500 '),
(330, 8, 'Barangay 501 '),
(331, 8, 'Barangay 502 '),
(332, 8, 'Barangay 503 '),
(333, 8, 'Barangay 504 '),
(334, 8, 'Barangay 505 '),
(335, 8, 'Barangay 506 '),
(336, 8, 'Barangay 507 '),
(337, 8, 'Barangay 508 '),
(338, 8, 'Barangay 509 '),
(339, 8, 'Barangay 510 '),
(340, 8, 'Barangay 511 '),
(341, 8, 'Barangay 512 '),
(342, 8, 'Barangay 513 '),
(343, 8, 'Barangay 514 '),
(344, 8, 'Barangay 515 '),
(345, 8, 'Barangay 516 '),
(346, 8, 'Barangay 517 '),
(347, 8, 'Barangay 518 '),
(348, 8, 'Barangay 519 '),
(349, 8, 'Barangay 520 '),
(350, 8, 'Barangay 521 '),
(351, 8, 'Barangay 522 '),
(352, 8, 'Barangay 523 '),
(353, 8, 'Barangay 524 '),
(354, 8, 'Barangay 525 '),
(355, 8, 'Barangay 526 '),
(356, 8, 'Barangay 527 '),
(357, 8, 'Barangay 528 '),
(358, 8, 'Barangay 529 '),
(359, 8, 'Barangay 530 '),
(360, 8, 'Barangay 531 '),
(361, 8, 'Barangay 532 '),
(362, 8, 'Barangay 533 '),
(363, 8, 'Barangay 534 '),
(364, 8, 'Barangay 535 '),
(365, 8, 'Barangay 536 '),
(366, 8, 'Barangay 537 '),
(367, 8, 'Barangay 538 '),
(368, 8, 'Barangay 539 '),
(369, 8, 'Barangay 540 '),
(370, 8, 'Barangay 541 '),
(371, 8, 'Barangay 542 '),
(372, 8, 'Barangay 543 '),
(373, 8, 'Barangay 544 '),
(374, 8, 'Barangay 545 '),
(375, 8, 'Barangay 546 '),
(376, 8, 'Barangay 547 '),
(377, 8, 'Barangay 548 '),
(378, 8, 'Barangay 549 '),
(379, 8, 'Barangay 550 '),
(380, 8, 'Barangay 551 '),
(381, 8, 'Barangay 552 '),
(382, 8, 'Barangay 553 '),
(383, 8, 'Barangay 554 '),
(384, 8, 'Barangay 555 '),
(385, 8, 'Barangay 556 '),
(386, 8, 'Barangay 557 '),
(387, 8, 'Barangay 558 '),
(388, 8, 'Barangay 559 '),
(389, 8, 'Barangay 560 '),
(390, 8, 'Barangay 561 '),
(391, 8, 'Barangay 562 '),
(392, 8, 'Barangay 563 '),
(393, 8, 'Barangay 564 '),
(394, 8, 'Barangay 565 '),
(395, 8, 'Barangay 566 '),
(396, 8, 'Barangay 567 '),
(397, 8, 'Barangay 568 '),
(398, 8, 'Barangay 569 '),
(399, 8, 'Barangay 570 '),
(400, 8, 'Barangay 571 '),
(401, 8, 'Barangay 572 '),
(402, 8, 'Barangay 573 '),
(403, 8, 'Barangay 574 '),
(404, 8, 'Barangay 575 '),
(405, 8, 'Barangay 576 '),
(406, 8, 'Barangay 577 '),
(407, 8, 'Barangay 578 '),
(408, 8, 'Barangay 579 '),
(409, 8, 'Barangay 580 '),
(410, 8, 'Barangay 581 '),
(411, 8, 'Barangay 582 '),
(412, 8, 'Barangay 583 '),
(413, 8, 'Barangay 584 '),
(414, 8, 'Barangay 585 '),
(415, 8, 'Barangay 586 '),
(416, 8, 'Barangay 587 '),
(419, 8, 'Barangay 587 - A'),
(420, 8, 'Barangay 588 '),
(421, 8, 'Barangay 589 '),
(422, 8, 'Barangay 590 '),
(423, 8, 'Barangay 591 '),
(424, 8, 'Barangay 592 '),
(425, 8, 'Barangay 593 '),
(426, 8, 'Barangay 594 '),
(427, 8, 'Barangay 595 '),
(428, 8, 'Barangay 596 '),
(429, 8, 'Barangay 597 '),
(430, 8, 'Barangay 598 '),
(431, 8, 'Barangay 599 '),
(432, 8, 'Barangay 600 '),
(433, 8, 'Barangay 601 '),
(434, 8, 'Barangay 602 '),
(435, 8, 'Barangay 603 '),
(436, 8, 'Barangay 604 '),
(437, 8, 'Barangay 605 '),
(438, 8, 'Barangay 606 '),
(439, 8, 'Barangay 607 '),
(440, 8, 'Barangay 608 '),
(441, 8, 'Barangay 609 '),
(442, 8, 'Barangay 610 '),
(443, 8, 'Barangay 611 '),
(444, 8, 'Barangay 612 '),
(445, 8, 'Barangay 613 '),
(446, 8, 'Barangay 614 '),
(447, 8, 'Barangay 615 '),
(448, 8, 'Barangay 616 '),
(449, 8, 'Barangay 617 '),
(450, 8, 'Barangay 618 '),
(451, 8, 'Barangay 619 '),
(452, 8, 'Barangay 620 '),
(453, 8, 'Barangay 621 '),
(454, 8, 'Barangay 622 '),
(455, 8, 'Barangay 623 '),
(456, 8, 'Barangay 624 '),
(457, 8, 'Barangay 625 '),
(458, 8, 'Barangay 626 '),
(459, 8, 'Barangay 627 '),
(460, 8, 'Barangay 628 '),
(461, 8, 'Barangay 629 '),
(462, 8, 'Barangay 630 '),
(463, 8, 'Barangay 631 '),
(464, 8, 'Barangay 632 '),
(465, 8, 'Barangay 633 '),
(466, 8, 'Barangay 634 '),
(467, 8, 'Barangay 635 '),
(468, 8, 'Barangay 636 '),
(469, 11, 'Barangay 637 '),
(470, 11, 'Barangay 638 '),
(471, 11, 'Barangay 639 '),
(472, 11, 'Barangay 640 '),
(473, 11, 'Barangay 641 '),
(474, 11, 'Barangay 642 '),
(475, 11, 'Barangay 643 '),
(476, 11, 'Barangay 644 '),
(477, 11, 'Barangay 645 '),
(478, 11, 'Barangay 646 '),
(479, 11, 'Barangay 647 '),
(480, 11, 'Barangay 648 '),
(481, 12, 'Barangay 268 '),
(482, 12, 'Barangay 269 '),
(483, 12, 'Barangay 270 '),
(484, 12, 'Barangay 271 '),
(485, 12, 'Barangay 272 '),
(486, 12, 'Barangay 273 '),
(487, 12, 'Barangay 274 '),
(488, 12, 'Barangay 275 '),
(489, 12, 'Barangay 276 '),
(490, 12, 'Barangay 281 '),
(491, 12, 'Barangay 282 '),
(492, 12, 'Barangay 283 '),
(493, 12, 'Barangay 284 '),
(494, 12, 'Barangay 285 '),
(495, 12, 'Barangay 286 '),
(496, 13, 'Barangay 745 '),
(497, 13, 'Barangay 746 '),
(498, 13, 'Barangay 747 '),
(499, 13, 'Barangay 748 '),
(500, 13, 'Barangay 749 '),
(501, 13, 'Barangay 750 '),
(502, 13, 'Barangay 751 '),
(503, 13, 'Barangay 752 '),
(504, 13, 'Barangay 753 '),
(505, 13, 'Barangay 754 '),
(506, 13, 'Barangay 755 '),
(507, 13, 'Barangay 756 '),
(508, 13, 'Barangay 757 '),
(509, 13, 'Barangay 758 '),
(510, 13, 'Barangay 759 '),
(511, 13, 'Barangay 760 '),
(512, 13, 'Barangay 761 '),
(513, 13, 'Barangay 762 '),
(514, 13, 'Barangay 763 '),
(515, 13, 'Barangay 764 '),
(516, 13, 'Barangay 765 '),
(517, 13, 'Barangay 766 '),
(518, 13, 'Barangay 767 '),
(519, 13, 'Barangay 768 '),
(520, 13, 'Barangay 769 '),
(521, 13, 'Barangay 770 '),
(522, 13, 'Barangay 771 '),
(523, 13, 'Barangay 772 '),
(524, 13, 'Barangay 773 '),
(525, 13, 'Barangay 774 '),
(526, 13, 'Barangay 775 '),
(527, 13, 'Barangay 776 '),
(528, 13, 'Barangay 777 '),
(529, 13, 'Barangay 778 '),
(530, 13, 'Barangay 779 '),
(531, 13, 'Barangay 780 '),
(532, 13, 'Barangay 781 '),
(533, 13, 'Barangay 782 '),
(534, 13, 'Barangay 783 '),
(535, 13, 'Barangay 784 '),
(536, 13, 'Barangay 785 '),
(537, 13, 'Barangay 786 '),
(538, 13, 'Barangay 787 '),
(539, 13, 'Barangay 788 '),
(540, 13, 'Barangay 789 '),
(541, 13, 'Barangay 790 '),
(542, 13, 'Barangay 791 '),
(543, 13, 'Barangay 792 '),
(544, 13, 'Barangay 793 '),
(545, 13, 'Barangay 794 '),
(546, 13, 'Barangay 795 '),
(547, 13, 'Barangay 796 '),
(548, 13, 'Barangay 797 '),
(549, 13, 'Barangay 798 '),
(550, 13, 'Barangay 799 '),
(551, 13, 'Barangay 800 '),
(552, 13, 'Barangay 801 '),
(553, 13, 'Barangay 802 '),
(554, 13, 'Barangay 803 '),
(555, 13, 'Barangay 804 '),
(556, 13, 'Barangay 805 '),
(557, 13, 'Barangay 806 '),
(558, 13, 'Barangay 807 '),
(559, 13, 'Barangay 808 '),
(560, 13, 'Barangay 818 - A'),
(561, 13, 'Barangay 866 '),
(562, 13, 'Barangay 873 '),
(563, 13, 'Barangay 874 '),
(564, 13, 'Barangay 875 '),
(565, 13, 'Barangay 876 '),
(566, 13, 'Barangay 877 '),
(567, 13, 'Barangay 878 '),
(568, 13, 'Barangay 879 '),
(569, 13, 'Barangay 880 '),
(570, 13, 'Barangay 881 '),
(571, 13, 'Barangay 882 '),
(572, 13, 'Barangay 883 '),
(573, 13, 'Barangay 884 '),
(574, 13, 'Barangay 885 '),
(575, 13, 'Barangay 886 '),
(576, 13, 'Barangay 887 '),
(577, 13, 'Barangay 888 '),
(578, 13, 'Barangay 889 '),
(579, 13, 'Barangay 890 '),
(580, 13, 'Barangay 891 '),
(581, 13, 'Barangay 892 '),
(582, 13, 'Barangay 893 '),
(583, 13, 'Barangay 894 '),
(584, 13, 'Barangay 895 '),
(585, 13, 'Barangay 896 '),
(586, 13, 'Barangay 897 '),
(587, 13, 'Barangay 898 '),
(588, 13, 'Barangay 899 '),
(589, 13, 'Barangay 900 '),
(590, 13, 'Barangay 901 '),
(591, 13, 'Barangay 902 '),
(592, 13, 'Barangay 903 '),
(593, 13, 'Barangay 904 '),
(594, 13, 'Barangay 905 '),
(595, 15, 'Barangay 297 '),
(596, 15, 'Barangay 298 '),
(597, 15, 'Barangay 299 '),
(598, 15, 'Barangay 300 '),
(599, 15, 'Barangay 301 '),
(600, 15, 'Barangay 302 '),
(601, 15, 'Barangay 303 '),
(602, 15, 'Barangay 304 '),
(603, 15, 'Barangay 305 '),
(604, 15, 'Barangay 310 '),
(605, 15, 'Barangay 311 '),
(606, 15, 'Barangay 312 '),
(607, 15, 'Barangay 313 '),
(608, 15, 'Barangay 314 '),
(609, 15, 'Barangay 315 '),
(610, 15, 'Barangay 316 '),
(611, 15, 'Barangay 317 '),
(612, 15, 'Barangay 318 '),
(613, 15, 'Barangay 319 '),
(614, 15, 'Barangay 320 '),
(615, 15, 'Barangay 321 '),
(616, 15, 'Barangay 322 '),
(617, 15, 'Barangay 323 '),
(618, 15, 'Barangay 324 '),
(619, 15, 'Barangay 325 '),
(620, 15, 'Barangay 326 '),
(621, 15, 'Barangay 327 '),
(622, 15, 'Barangay 328 '),
(623, 15, 'Barangay 329 '),
(624, 15, 'Barangay 330 '),
(625, 15, 'Barangay 331 '),
(626, 15, 'Barangay 332 '),
(627, 15, 'Barangay 333 '),
(628, 15, 'Barangay 334 '),
(629, 15, 'Barangay 335 '),
(630, 15, 'Barangay 336 '),
(631, 15, 'Barangay 337 '),
(632, 15, 'Barangay 338 '),
(633, 15, 'Barangay 339 '),
(634, 15, 'Barangay 340 '),
(635, 15, 'Barangay 341 '),
(636, 15, 'Barangay 342 '),
(637, 15, 'Barangay 343 '),
(638, 15, 'Barangay 344 '),
(639, 15, 'Barangay 345 '),
(640, 15, 'Barangay 346 '),
(641, 15, 'Barangay 347 '),
(642, 14, 'Barangay 348 '),
(643, 14, 'Barangay 349 '),
(644, 14, 'Barangay 350 '),
(645, 14, 'Barangay 351 '),
(646, 14, 'Barangay 352 '),
(647, 14, 'Barangay 353 '),
(648, 14, 'Barangay 354 '),
(649, 14, 'Barangay 355 '),
(650, 14, 'Barangay 356 '),
(651, 14, 'Barangay 357 '),
(652, 14, 'Barangay 358 '),
(653, 14, 'Barangay 359 '),
(654, 14, 'Barangay 360 '),
(655, 14, 'Barangay 361 '),
(656, 14, 'Barangay 362 '),
(657, 14, 'Barangay 363 '),
(658, 14, 'Barangay 364 '),
(659, 14, 'Barangay 365 '),
(660, 14, 'Barangay 366 '),
(661, 14, 'Barangay 367 '),
(662, 14, 'Barangay 368 '),
(663, 14, 'Barangay 369 '),
(664, 14, 'Barangay 370 '),
(665, 14, 'Barangay 371 '),
(666, 14, 'Barangay 372 '),
(667, 14, 'Barangay 373 '),
(668, 14, 'Barangay 374 '),
(669, 14, 'Barangay 375 '),
(670, 14, 'Barangay 376 '),
(671, 14, 'Barangay 377 '),
(672, 14, 'Barangay 378 '),
(673, 14, 'Barangay 379 '),
(674, 14, 'Barangay 380 '),
(675, 14, 'Barangay 381 '),
(676, 14, 'Barangay 382 '),
(677, 18, 'Barangay 1 '),
(678, 18, 'Barangay 2 '),
(679, 18, 'Barangay 3 '),
(680, 18, 'Barangay 4 '),
(681, 18, 'Barangay 5 '),
(682, 18, 'Barangay 6 '),
(683, 18, 'Barangay 7 '),
(684, 18, 'Barangay 8 '),
(685, 18, 'Barangay 9 '),
(686, 18, 'Barangay 10 '),
(687, 18, 'Barangay 11 '),
(688, 18, 'Barangay 12 '),
(689, 18, 'Barangay 13 '),
(690, 18, 'Barangay 14 '),
(691, 18, 'Barangay 15 '),
(692, 18, 'Barangay 16 '),
(693, 18, 'Barangay 17 '),
(694, 18, 'Barangay 18 '),
(695, 18, 'Barangay 19 '),
(696, 18, 'Barangay 20 '),
(697, 18, 'Barangay 21 '),
(698, 18, 'Barangay 22 '),
(699, 18, 'Barangay 23 '),
(700, 18, 'Barangay 24 '),
(701, 18, 'Barangay 25 '),
(702, 18, 'Barangay 26 '),
(703, 18, 'Barangay 27 '),
(704, 18, 'Barangay 28 '),
(705, 18, 'Barangay 29 '),
(706, 18, 'Barangay 30 '),
(707, 18, 'Barangay 31 '),
(708, 18, 'Barangay 32 '),
(709, 18, 'Barangay 33 '),
(710, 18, 'Barangay 34 '),
(711, 18, 'Barangay 35 '),
(712, 18, 'Barangay 36 '),
(713, 18, 'Barangay 37 '),
(714, 18, 'Barangay 38 '),
(715, 18, 'Barangay 39 '),
(716, 18, 'Barangay 40 '),
(717, 18, 'Barangay 41 '),
(718, 18, 'Barangay 42 '),
(719, 18, 'Barangay 43 '),
(720, 18, 'Barangay 44 '),
(721, 18, 'Barangay 45 '),
(722, 18, 'Barangay 46 '),
(723, 18, 'Barangay 47 '),
(724, 18, 'Barangay 48 '),
(725, 18, 'Barangay 49 '),
(726, 18, 'Barangay 50 '),
(727, 18, 'Barangay 51 '),
(728, 18, 'Barangay 52 '),
(729, 18, 'Barangay 53 '),
(730, 18, 'Barangay 54 '),
(731, 18, 'Barangay 55 '),
(732, 18, 'Barangay 56 '),
(733, 18, 'Barangay 57 '),
(734, 18, 'Barangay 58 '),
(735, 18, 'Barangay 59 '),
(736, 18, 'Barangay 60 '),
(737, 18, 'Barangay 61 '),
(738, 18, 'Barangay 62 '),
(739, 18, 'Barangay 63 '),
(740, 18, 'Barangay 64 '),
(741, 18, 'Barangay 65 '),
(742, 18, 'Barangay 66 '),
(743, 18, 'Barangay 67 '),
(744, 18, 'Barangay 68 '),
(745, 18, 'Barangay 69 '),
(746, 18, 'Barangay 70 '),
(747, 18, 'Barangay 71 '),
(748, 18, 'Barangay 72 '),
(749, 18, 'Barangay 73 '),
(750, 18, 'Barangay 74 '),
(751, 18, 'Barangay 75 '),
(752, 18, 'Barangay 76 '),
(753, 18, 'Barangay 77 '),
(754, 18, 'Barangay 78 '),
(755, 18, 'Barangay 79 '),
(756, 18, 'Barangay 80 '),
(757, 18, 'Barangay 81 '),
(758, 18, 'Barangay 82 '),
(759, 18, 'Barangay 83 '),
(760, 18, 'Barangay 84 '),
(761, 18, 'Barangay 85 '),
(762, 18, 'Barangay 86 '),
(763, 18, 'Barangay 87 '),
(764, 18, 'Barangay 88 '),
(765, 18, 'Barangay 89 '),
(766, 18, 'Barangay 90 '),
(767, 18, 'Barangay 91 '),
(768, 18, 'Barangay 92 '),
(769, 18, 'Barangay 93 '),
(770, 18, 'Barangay 94 '),
(771, 18, 'Barangay 95 '),
(772, 18, 'Barangay 96 '),
(773, 18, 'Barangay 97 '),
(774, 18, 'Barangay 98 '),
(775, 18, 'Barangay 99 '),
(776, 18, 'Barangay 100 '),
(777, 18, 'Barangay 101 '),
(778, 18, 'Barangay 102 '),
(779, 18, 'Barangay 103 '),
(780, 18, 'Barangay 104 '),
(781, 18, 'Barangay 105 '),
(782, 18, 'Barangay 106 '),
(783, 18, 'Barangay 107 '),
(784, 18, 'Barangay 108 '),
(785, 18, 'Barangay 109 '),
(786, 18, 'Barangay 110 '),
(787, 18, 'Barangay 111 '),
(788, 18, 'Barangay 112 '),
(789, 18, 'Barangay 113 '),
(790, 18, 'Barangay 114 '),
(791, 18, 'Barangay 115 '),
(792, 18, 'Barangay 116 '),
(793, 18, 'Barangay 117 '),
(794, 18, 'Barangay 118 '),
(795, 18, 'Barangay 119 '),
(796, 18, 'Barangay 120 '),
(797, 18, 'Barangay 121 '),
(798, 18, 'Barangay 122 '),
(799, 18, 'Barangay 123 '),
(800, 18, 'Barangay 124 '),
(801, 18, 'Barangay 125 '),
(802, 18, 'Barangay 126 '),
(803, 18, 'Barangay 127 '),
(804, 18, 'Barangay 128 '),
(805, 18, 'Barangay 129 '),
(806, 18, 'Barangay 130 '),
(807, 18, 'Barangay 131 '),
(808, 18, 'Barangay 132 '),
(809, 18, 'Barangay 133 '),
(810, 18, 'Barangay 134 '),
(811, 18, 'Barangay 135 '),
(812, 18, 'Barangay 136 '),
(813, 18, 'Barangay 137 '),
(814, 18, 'Barangay 138 '),
(815, 18, 'Barangay 139 '),
(816, 18, 'Barangay 140 '),
(817, 18, 'Barangay 141 '),
(818, 18, 'Barangay 142 '),
(819, 18, 'Barangay 143 '),
(820, 18, 'Barangay 144 '),
(821, 18, 'Barangay 145 '),
(822, 18, 'Barangay 146 '),
(823, 18, 'Barangay 147 '),
(824, 18, 'Barangay 148 '),
(825, 18, 'Barangay 149 '),
(826, 18, 'Barangay 150 '),
(827, 18, 'Barangay 151 '),
(828, 18, 'Barangay 152 '),
(829, 18, 'Barangay 153 '),
(830, 18, 'Barangay 154 '),
(831, 18, 'Barangay 155 '),
(832, 18, 'Barangay 156 '),
(833, 18, 'Barangay 157 '),
(834, 18, 'Barangay 158 '),
(835, 18, 'Barangay 159 '),
(836, 18, 'Barangay 160 '),
(837, 18, 'Barangay 161 '),
(838, 18, 'Barangay 162 '),
(839, 18, 'Barangay 163 '),
(840, 18, 'Barangay 164 '),
(841, 18, 'Barangay 165 '),
(842, 18, 'Barangay 166 '),
(843, 18, 'Barangay 167 '),
(844, 18, 'Barangay 168 '),
(845, 18, 'Barangay 169 '),
(846, 18, 'Barangay 170 '),
(847, 18, 'Barangay 171 '),
(848, 18, 'Barangay 172 '),
(849, 18, 'Barangay 173 '),
(850, 18, 'Barangay 174 '),
(851, 18, 'Barangay 175 '),
(852, 18, 'Barangay 176 '),
(853, 18, 'Barangay 177 '),
(854, 18, 'Barangay 178 '),
(855, 18, 'Barangay 179 '),
(856, 18, 'Barangay 180 '),
(857, 18, 'Barangay 181 '),
(858, 18, 'Barangay 182 '),
(859, 18, 'Barangay 183 '),
(860, 18, 'Barangay 184 '),
(861, 18, 'Barangay 185 '),
(862, 18, 'Barangay 186 '),
(863, 18, 'Barangay 187 '),
(864, 18, 'Barangay 188 '),
(865, 18, 'Barangay 189 '),
(866, 18, 'Barangay 190 '),
(867, 18, 'Barangay 191 '),
(868, 18, 'Barangay 192 '),
(869, 18, 'Barangay 193 '),
(870, 18, 'Barangay 194 '),
(871, 18, 'Barangay 195 '),
(872, 18, 'Barangay 196 '),
(873, 18, 'Barangay 197 '),
(874, 18, 'Barangay 198 '),
(875, 18, 'Barangay 199 '),
(876, 18, 'Barangay 200 '),
(877, 18, 'Barangay 201 '),
(878, 18, 'Barangay 202 '),
(879, 18, 'Barangay 203 '),
(880, 18, 'Barangay 204 '),
(881, 18, 'Barangay 205 '),
(882, 18, 'Barangay 206 '),
(883, 18, 'Barangay 207 '),
(884, 18, 'Barangay 208 '),
(885, 18, 'Barangay 209 '),
(886, 18, 'Barangay 210 '),
(887, 18, 'Barangay 211 '),
(888, 18, 'Barangay 212 '),
(889, 18, 'Barangay 213 '),
(890, 18, 'Barangay 214 '),
(891, 18, 'Barangay 215 '),
(892, 18, 'Barangay 216 '),
(893, 18, 'Barangay 217 '),
(894, 18, 'Barangay 218 '),
(895, 18, 'Barangay 219 '),
(896, 18, 'Barangay 220 '),
(897, 18, 'Barangay 221 '),
(898, 18, 'Barangay 222 '),
(899, 18, 'Barangay 223 '),
(900, 18, 'Barangay 224 '),
(901, 18, 'Barangay 225 '),
(902, 18, 'Barangay 226 '),
(903, 18, 'Barangay 227 '),
(904, 18, 'Barangay 228 '),
(905, 18, 'Barangay 229 '),
(906, 18, 'Barangay 230 '),
(907, 18, 'Barangay 231 '),
(908, 18, 'Barangay 232 '),
(909, 18, 'Barangay 233 '),
(910, 18, 'Barangay 234 '),
(911, 18, 'Barangay 235 '),
(912, 18, 'Barangay 236 '),
(913, 18, 'Barangay 237 '),
(914, 18, 'Barangay 238 '),
(915, 18, 'Barangay 239 '),
(916, 18, 'Barangay 240 '),
(917, 18, 'Barangay 241 '),
(918, 18, 'Barangay 242 '),
(919, 18, 'Barangay 243 '),
(920, 18, 'Barangay 244 '),
(921, 18, 'Barangay 245 '),
(922, 18, 'Barangay 246 '),
(923, 18, 'Barangay 247 '),
(924, 18, 'Barangay 248 '),
(925, 18, 'Barangay 249 '),
(926, 18, 'Barangay 250 '),
(927, 18, 'Barangay 251 '),
(928, 18, 'Barangay 252 '),
(929, 18, 'Barangay 253 '),
(930, 18, 'Barangay 254 '),
(931, 18, 'Barangay 255 '),
(932, 18, 'Barangay 256 '),
(933, 18, 'Barangay 257 '),
(934, 18, 'Barangay 258 '),
(935, 18, 'Barangay 259 '),
(936, 18, 'Barangay 260 '),
(937, 18, 'Barangay 261 '),
(938, 18, 'Barangay 262 '),
(939, 18, 'Barangay 263 '),
(940, 18, 'Barangay 264 '),
(941, 18, 'Barangay 265 '),
(942, 18, 'Barangay 266 '),
(943, 18, 'Barangay 267 '),
(944, 31, 'Bagong Silang'),
(945, 31, 'Bagumbayan'),
(946, 31, 'Bagumbayan'),
(947, 31, 'Bonifacio Global City'),
(948, 31, 'Calzada'),
(949, 31, 'Central Signal Village (Signal Village)'),
(950, 31, 'Fort Bonifacio'),
(951, 31, 'FTI PNR Road'),
(952, 31, 'Hagonoy'),
(953, 31, 'Katuparan'),
(954, 31, 'Maharlika Village'),
(955, 31, 'Napindan'),
(956, 31, 'New Lower Bicutan'),
(957, 31, 'North Daang Hari'),
(958, 31, 'North Signal Village'),
(959, 31, 'Palingon'),
(960, 31, 'Pinagsama'),
(961, 31, 'San Miguel'),
(962, 31, 'Santa Ana'),
(963, 31, 'South Daang Hari'),
(964, 31, 'South Signal Village'),
(965, 31, 'Tanyag (Bagong Tanyag)'),
(966, 31, 'Ususan'),
(967, 31, 'Wawa'),
(968, 31, 'Western Bicutan'),
(969, 28, 'Central Bicutan'),
(970, 29, 'Lower Bicutan'),
(971, 30, 'Upper Bicutan'),
(972, 34, 'Tuktukan'),
(973, 32, 'Ibayo-Tipas'),
(974, 32, 'Ligid-Tipas');

-- --------------------------------------------------------

--
-- Table structure for table `table_city`
--

CREATE TABLE `table_city` (
  `city_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `table_city`
--

INSERT INTO `table_city` (`city_id`, `name`) VALUES
(1, 'Manila'),
(2, 'Mandaluyong'),
(3, 'Taguig');

-- --------------------------------------------------------

--
-- Table structure for table `table_class`
--

CREATE TABLE `table_class` (
  `class_id` int(11) NOT NULL,
  `sy_id` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `room_id` int(11) NOT NULL,
  `level_section_id` int(11) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_class`
--

INSERT INTO `table_class` (`class_id`, `sy_id`, `teacher_id`, `room_id`, `level_section_id`, `created_date`, `created_by`, `updated_date`, `updated_by`, `deleted_date`, `deleted_by`) VALUES
(1, 1, 8, 0, 1, '', '', '', '', '', ''),
(2, 1, 34, 0, 2, '', '', '', '', '', ''),
(3, 1, 33, 0, 3, '', '', '', '', '', ''),
(4, 1, 16, 0, 13, '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `table_delete_transaction`
--

CREATE TABLE `table_delete_transaction` (
  `delete_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  `deleted_data` int(11) NOT NULL,
  `delete_date` int(11) NOT NULL,
  `delete_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_department`
--

CREATE TABLE `table_department` (
  `department_id` int(11) NOT NULL,
  `subject_id` int(32) NOT NULL,
  `grade_level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_department`
--

INSERT INTO `table_department` (`department_id`, `subject_id`, `grade_level`) VALUES
(1, 2, 1),
(2, 2, 2),
(3, 2, 3),
(4, 2, 4),
(5, 3, 1),
(6, 3, 2),
(7, 3, 3),
(8, 3, 4),
(9, 4, 1),
(10, 4, 2),
(11, 4, 3),
(12, 4, 4),
(13, 5, 1),
(14, 5, 2),
(15, 5, 3),
(16, 5, 4),
(17, 6, 1),
(18, 6, 2),
(19, 6, 3),
(20, 6, 4),
(21, 6, 1),
(22, 6, 2),
(23, 6, 3),
(24, 6, 4),
(25, 7, 1),
(26, 7, 2),
(27, 7, 3),
(28, 7, 4),
(29, 8, 1),
(30, 8, 2),
(31, 8, 3),
(32, 8, 4),
(33, 9, 1),
(34, 9, 2),
(35, 9, 3),
(36, 9, 4);

-- --------------------------------------------------------

--
-- Table structure for table `table_enrollment`
--

CREATE TABLE `table_enrollment` (
  `enrollment_no` int(11) NOT NULL,
  `student_id` int(32) NOT NULL,
  `class_id` int(11) NOT NULL,
  `enrolled_date` varchar(32) NOT NULL,
  `enrolled_by` varchar(32) NOT NULL,
  `update_date` varchar(32) NOT NULL,
  `update_by` varchar(32) NOT NULL,
  `delete_date` varchar(32) NOT NULL,
  `delete_by` varchar(32) NOT NULL,
  `status_inactive` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_enrollment`
--

INSERT INTO `table_enrollment` (`enrollment_no`, `student_id`, `class_id`, `enrolled_date`, `enrolled_by`, `update_date`, `update_by`, `delete_date`, `delete_by`, `status_inactive`) VALUES
(1, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', '', 0),
(2, 2, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(3, 3, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(4, 4, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(5, 5, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(6, 6, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(7, 7, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(8, 8, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(9, 9, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(10, 10, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(11, 11, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(12, 12, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(13, 13, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(14, 14, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(15, 15, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(16, 16, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(17, 17, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(18, 18, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(19, 19, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(20, 20, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(21, 21, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(22, 22, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(23, 23, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(24, 24, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(25, 25, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(26, 26, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(27, 27, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(28, 28, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(29, 29, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(30, 30, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(31, 31, 1, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(32, 32, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(33, 33, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(34, 34, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(35, 35, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(36, 36, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(37, 37, 2, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(38, 38, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(39, 39, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(40, 40, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(41, 41, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(42, 42, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(43, 43, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0),
(44, 44, 3, '01/01/0001 12:00:00 am', '0', '', '', '', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `table_enrollment_period`
--

CREATE TABLE `table_enrollment_period` (
  `enrollment_period_id` int(11) NOT NULL,
  `sy_id` int(11) NOT NULL,
  `start_date` varchar(32) NOT NULL,
  `end_date` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_enrollment_settings`
--

CREATE TABLE `table_enrollment_settings` (
  `enrollment_settings_id` int(11) NOT NULL,
  `level_section_id` int(11) NOT NULL,
  `max_students` int(11) NOT NULL,
  `sy_id` int(32) NOT NULL,
  `enrollment_start` varchar(32) NOT NULL,
  `enrollment_end` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_enrollment_settings`
--

INSERT INTO `table_enrollment_settings` (`enrollment_settings_id`, `level_section_id`, `max_students`, `sy_id`, `enrollment_start`, `enrollment_end`) VALUES
(1, 1, 50, 1, '', ''),
(2, 2, 50, 1, '', ''),
(3, 3, 50, 1, '', ''),
(4, 1, 55, 2, '', ''),
(5, 13, 50, 2, '', ''),
(6, 14, 50, 2, '', ''),
(7, 15, 50, 2, '', ''),
(8, 2, 55, 2, '', ''),
(9, 1, 50, 2, '', ''),
(10, 1, 50, 2, '', ''),
(11, 1, 50, 2, '', ''),
(12, 2, 50, 2, '', ''),
(13, 3, 50, 2, '', ''),
(14, 13, 50, 2, '', ''),
(15, 14, 50, 2, '', ''),
(16, 15, 50, 2, '', ''),
(17, 1, 50, 1, '', ''),
(18, 1, 50, 1, '', ''),
(19, 1, 50, 1, '', ''),
(20, 2, 50, 1, '', ''),
(21, 3, 50, 1, '', ''),
(22, 13, 50, 1, '', '');

-- --------------------------------------------------------

--
-- Table structure for table `table_events`
--

CREATE TABLE `table_events` (
  `id` int(11) NOT NULL,
  `event_name` mediumtext NOT NULL,
  `event_description` mediumtext NOT NULL,
  `event_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `table_events`
--

INSERT INTO `table_events` (`id`, `event_name`, `event_description`, `event_status`) VALUES
(1, 'Eco-King and Queen 2020', 'Join us with the Celebration of Nutrition Month!\r\n\r\nWhat: Eco-King and Queen\r\nWhen: July 19, 2020\r\nWhere: Aquino Building, Main Hall', 0);

-- --------------------------------------------------------

--
-- Table structure for table `table_file_status`
--

CREATE TABLE `table_file_status` (
  `status_id` int(11) NOT NULL,
  `status` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_file_status`
--

INSERT INTO `table_file_status` (`status_id`, `status`) VALUES
(1, 'inactive'),
(2, 'active'),
(3, 'archived');

-- --------------------------------------------------------

--
-- Table structure for table `table_grades`
--

CREATE TABLE `table_grades` (
  `grade_id` int(11) NOT NULL,
  `sy_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `student_grade` int(11) NOT NULL,
  `grading_period_id` int(11) NOT NULL,
  `assignment_id` int(11) NOT NULL,
  `encode_date` varchar(32) NOT NULL,
  `encode_by` varchar(32) NOT NULL,
  `update_date` varchar(32) NOT NULL,
  `update_by` varchar(32) NOT NULL,
  `delete_date` varchar(32) NOT NULL,
  `delete_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_grades`
--

INSERT INTO `table_grades` (`grade_id`, `sy_id`, `student_id`, `student_grade`, `grading_period_id`, `assignment_id`, `encode_date`, `encode_by`, `update_date`, `update_by`, `delete_date`, `delete_by`) VALUES
(1, 1, 1, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(2, 1, 1, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(3, 1, 1, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(4, 1, 1, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(5, 1, 1, 90, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(6, 1, 1, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(7, 1, 1, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(8, 1, 1, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(9, 1, 1, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(10, 1, 1, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(11, 1, 1, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(12, 1, 1, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(13, 1, 1, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(14, 1, 1, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(15, 1, 1, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(16, 1, 1, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(17, 1, 1, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(18, 1, 1, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(19, 1, 1, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(20, 1, 1, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(21, 1, 1, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(22, 1, 1, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(23, 1, 1, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(24, 1, 1, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(25, 1, 1, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(26, 1, 1, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(27, 1, 1, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(28, 1, 1, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(29, 1, 1, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(30, 1, 1, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(31, 1, 1, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(32, 1, 1, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(33, 1, 2, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(34, 1, 2, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(35, 1, 2, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(36, 1, 2, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(37, 1, 2, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(38, 1, 2, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(39, 1, 2, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(40, 1, 2, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(41, 1, 2, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(42, 1, 2, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(43, 1, 2, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(44, 1, 2, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(45, 1, 2, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(46, 1, 2, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(47, 1, 2, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(48, 1, 2, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(49, 1, 2, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(50, 1, 2, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(51, 1, 2, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(52, 1, 2, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(53, 1, 2, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(54, 1, 2, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(55, 1, 2, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(56, 1, 2, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(57, 1, 2, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(58, 1, 2, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(59, 1, 2, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(60, 1, 2, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(61, 1, 2, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(62, 1, 2, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(63, 1, 2, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(64, 1, 2, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(65, 1, 3, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(66, 1, 3, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(67, 1, 3, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(68, 1, 3, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(69, 1, 3, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(70, 1, 3, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(71, 1, 3, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(72, 1, 3, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(73, 1, 3, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(74, 1, 3, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(75, 1, 3, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(76, 1, 3, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(77, 1, 3, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(78, 1, 3, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(79, 1, 3, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(80, 1, 3, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(81, 1, 3, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(82, 1, 3, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(83, 1, 3, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(84, 1, 3, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(85, 1, 3, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(86, 1, 3, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(87, 1, 3, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(88, 1, 3, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(89, 1, 3, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(90, 1, 3, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(91, 1, 3, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(92, 1, 3, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(93, 1, 3, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(94, 1, 3, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(95, 1, 3, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(96, 1, 3, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(97, 1, 4, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(98, 1, 4, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(99, 1, 4, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(100, 1, 4, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(101, 1, 4, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(102, 1, 4, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(103, 1, 4, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(104, 1, 4, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(105, 1, 4, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(106, 1, 4, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(107, 1, 4, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(108, 1, 4, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(109, 1, 4, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(110, 1, 4, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(111, 1, 4, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(112, 1, 4, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(113, 1, 4, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(114, 1, 4, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(115, 1, 4, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(116, 1, 4, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(117, 1, 4, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(118, 1, 4, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(119, 1, 4, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(120, 1, 4, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(121, 1, 4, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(122, 1, 4, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(123, 1, 4, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(124, 1, 4, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(125, 1, 4, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(126, 1, 4, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(127, 1, 4, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(128, 1, 4, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(129, 1, 5, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(130, 1, 5, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(131, 1, 5, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(132, 1, 5, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(133, 1, 5, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(134, 1, 5, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(135, 1, 5, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(136, 1, 5, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(137, 1, 5, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(138, 1, 5, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(139, 1, 5, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(140, 1, 5, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(141, 1, 5, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(142, 1, 5, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(143, 1, 5, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(144, 1, 5, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(145, 1, 5, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(146, 1, 5, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(147, 1, 5, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(148, 1, 5, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(149, 1, 5, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(150, 1, 5, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(151, 1, 5, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(152, 1, 5, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(153, 1, 5, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(154, 1, 5, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(155, 1, 5, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(156, 1, 5, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(157, 1, 5, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(158, 1, 5, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(159, 1, 5, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(160, 1, 5, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(161, 1, 6, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(162, 1, 6, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(163, 1, 6, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(164, 1, 6, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(165, 1, 6, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(166, 1, 6, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(167, 1, 6, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(168, 1, 6, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(169, 1, 6, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(170, 1, 6, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(171, 1, 6, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(172, 1, 6, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(173, 1, 6, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(174, 1, 6, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(175, 1, 6, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(176, 1, 6, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(177, 1, 6, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(178, 1, 6, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(179, 1, 6, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(180, 1, 6, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(181, 1, 6, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(182, 1, 6, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(183, 1, 6, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(184, 1, 6, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(185, 1, 6, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(186, 1, 6, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(187, 1, 6, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(188, 1, 6, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(189, 1, 6, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(190, 1, 6, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(191, 1, 6, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(192, 1, 6, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(193, 1, 7, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(194, 1, 7, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(195, 1, 7, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(196, 1, 7, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(197, 1, 7, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(198, 1, 7, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(199, 1, 7, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(200, 1, 7, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(201, 1, 7, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(202, 1, 7, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(203, 1, 7, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(204, 1, 7, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(205, 1, 7, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(206, 1, 7, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(207, 1, 7, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(208, 1, 7, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(209, 1, 7, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(210, 1, 7, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(211, 1, 7, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(212, 1, 7, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(213, 1, 7, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(214, 1, 7, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(215, 1, 7, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(216, 1, 7, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(217, 1, 7, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(218, 1, 7, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(219, 1, 7, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(220, 1, 7, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(221, 1, 7, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(222, 1, 7, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(223, 1, 7, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(224, 1, 7, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(225, 1, 8, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(226, 1, 8, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(227, 1, 8, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(228, 1, 8, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(229, 1, 8, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(230, 1, 8, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(231, 1, 8, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(232, 1, 8, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(233, 1, 8, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(234, 1, 8, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(235, 1, 8, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(236, 1, 8, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(237, 1, 8, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(238, 1, 8, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(239, 1, 8, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(240, 1, 8, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(241, 1, 8, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(242, 1, 8, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(243, 1, 8, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(244, 1, 8, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(245, 1, 8, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(246, 1, 8, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(247, 1, 8, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(248, 1, 8, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(249, 1, 8, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(250, 1, 8, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(251, 1, 8, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(252, 1, 8, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(253, 1, 8, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(254, 1, 8, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(255, 1, 8, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(256, 1, 8, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(257, 1, 9, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(258, 1, 9, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(259, 1, 9, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(260, 1, 9, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(261, 1, 9, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(262, 1, 9, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(263, 1, 9, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(264, 1, 9, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(265, 1, 9, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(266, 1, 9, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(267, 1, 9, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(268, 1, 9, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(269, 1, 9, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(270, 1, 9, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(271, 1, 9, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(272, 1, 9, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(273, 1, 9, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(274, 1, 9, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(275, 1, 9, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(276, 1, 9, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(277, 1, 9, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(278, 1, 9, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(279, 1, 9, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(280, 1, 9, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(281, 1, 9, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(282, 1, 9, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(283, 1, 9, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(284, 1, 9, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(285, 1, 9, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(286, 1, 9, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(287, 1, 9, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(288, 1, 9, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(289, 1, 10, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(290, 1, 10, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(291, 1, 10, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(292, 1, 10, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(293, 1, 10, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(294, 1, 10, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(295, 1, 10, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(296, 1, 10, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(297, 1, 10, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(298, 1, 10, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(299, 1, 10, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(300, 1, 10, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(301, 1, 10, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(302, 1, 10, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(303, 1, 10, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(304, 1, 10, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(305, 1, 10, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(306, 1, 10, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(307, 1, 10, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(308, 1, 10, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(309, 1, 10, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(310, 1, 10, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(311, 1, 10, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(312, 1, 10, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(313, 1, 10, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(314, 1, 10, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(315, 1, 10, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(316, 1, 10, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(317, 1, 10, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(318, 1, 10, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(319, 1, 10, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(320, 1, 10, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(321, 1, 11, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(322, 1, 11, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(323, 1, 11, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(324, 1, 11, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(325, 1, 11, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(326, 1, 11, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(327, 1, 11, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(328, 1, 11, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(329, 1, 11, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(330, 1, 11, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(331, 1, 11, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(332, 1, 11, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(333, 1, 11, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(334, 1, 11, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(335, 1, 11, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(336, 1, 11, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(337, 1, 11, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(338, 1, 11, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(339, 1, 11, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(340, 1, 11, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(341, 1, 11, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(342, 1, 11, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(343, 1, 11, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(344, 1, 11, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(345, 1, 11, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(346, 1, 11, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(347, 1, 11, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(348, 1, 11, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(349, 1, 11, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(350, 1, 11, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(351, 1, 11, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(352, 1, 11, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(353, 1, 12, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(354, 1, 12, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(355, 1, 12, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(356, 1, 12, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(357, 1, 12, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(358, 1, 12, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(359, 1, 12, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(360, 1, 12, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(361, 1, 12, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(362, 1, 12, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(363, 1, 12, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(364, 1, 12, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(365, 1, 12, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(366, 1, 12, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(367, 1, 12, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(368, 1, 12, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(369, 1, 12, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(370, 1, 12, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(371, 1, 12, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(372, 1, 12, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(373, 1, 12, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(374, 1, 12, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(375, 1, 12, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(376, 1, 12, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(377, 1, 12, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(378, 1, 12, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(379, 1, 12, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(380, 1, 12, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(381, 1, 12, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(382, 1, 12, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(383, 1, 12, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(384, 1, 12, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(385, 1, 13, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(386, 1, 13, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(387, 1, 13, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(388, 1, 13, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(389, 1, 13, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(390, 1, 13, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(391, 1, 13, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(392, 1, 13, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(393, 1, 13, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(394, 1, 13, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(395, 1, 13, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(396, 1, 13, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(397, 1, 13, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(398, 1, 13, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(399, 1, 13, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(400, 1, 13, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(401, 1, 13, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(402, 1, 13, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(403, 1, 13, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(404, 1, 13, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(405, 1, 13, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(406, 1, 13, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(407, 1, 13, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(408, 1, 13, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(409, 1, 13, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(410, 1, 13, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(411, 1, 13, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(412, 1, 13, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(413, 1, 13, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(414, 1, 13, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(415, 1, 13, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(416, 1, 13, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(417, 1, 14, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(418, 1, 14, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(419, 1, 14, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(420, 1, 14, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(421, 1, 14, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(422, 1, 14, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(423, 1, 14, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(424, 1, 14, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(425, 1, 14, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(426, 1, 14, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(427, 1, 14, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(428, 1, 14, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(429, 1, 14, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(430, 1, 14, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(431, 1, 14, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(432, 1, 14, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(433, 1, 14, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(434, 1, 14, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(435, 1, 14, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(436, 1, 14, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(437, 1, 14, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(438, 1, 14, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(439, 1, 14, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(440, 1, 14, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(441, 1, 14, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(442, 1, 14, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(443, 1, 14, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(444, 1, 14, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(445, 1, 14, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(446, 1, 14, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(447, 1, 14, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(448, 1, 14, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(449, 1, 15, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(450, 1, 15, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(451, 1, 15, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(452, 1, 15, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(453, 1, 15, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(454, 1, 15, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(455, 1, 15, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(456, 1, 15, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(457, 1, 15, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(458, 1, 15, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(459, 1, 15, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(460, 1, 15, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(461, 1, 15, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(462, 1, 15, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(463, 1, 15, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(464, 1, 15, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(465, 1, 15, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(466, 1, 15, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(467, 1, 15, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(468, 1, 15, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(469, 1, 15, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(470, 1, 15, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(471, 1, 15, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(472, 1, 15, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(473, 1, 15, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(474, 1, 15, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(475, 1, 15, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(476, 1, 15, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(477, 1, 15, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(478, 1, 15, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(479, 1, 15, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(480, 1, 15, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(481, 1, 16, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(482, 1, 16, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(483, 1, 16, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(484, 1, 16, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(485, 1, 16, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(486, 1, 16, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(487, 1, 16, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(488, 1, 16, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(489, 1, 16, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(490, 1, 16, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(491, 1, 16, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(492, 1, 16, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(493, 1, 16, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(494, 1, 16, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(495, 1, 16, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(496, 1, 16, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(497, 1, 16, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(498, 1, 16, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(499, 1, 16, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(500, 1, 16, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(501, 1, 16, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(502, 1, 16, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(503, 1, 16, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(504, 1, 16, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(505, 1, 16, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(506, 1, 16, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(507, 1, 16, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(508, 1, 16, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(509, 1, 16, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(510, 1, 16, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(511, 1, 16, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(512, 1, 16, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(513, 1, 17, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(514, 1, 17, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(515, 1, 17, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(516, 1, 17, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(517, 1, 17, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(518, 1, 17, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(519, 1, 17, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(520, 1, 17, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(521, 1, 17, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(522, 1, 17, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(523, 1, 17, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(524, 1, 17, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(525, 1, 17, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(526, 1, 17, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(527, 1, 17, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(528, 1, 17, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(529, 1, 17, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(530, 1, 17, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(531, 1, 17, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(532, 1, 17, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(533, 1, 17, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(534, 1, 17, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(535, 1, 17, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(536, 1, 17, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(537, 1, 17, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(538, 1, 17, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(539, 1, 17, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(540, 1, 17, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(541, 1, 17, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(542, 1, 17, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(543, 1, 17, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(544, 1, 17, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(545, 1, 18, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(546, 1, 18, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(547, 1, 18, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(548, 1, 18, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(549, 1, 18, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(550, 1, 18, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(551, 1, 18, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(552, 1, 18, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(553, 1, 18, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(554, 1, 18, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(555, 1, 18, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(556, 1, 18, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(557, 1, 18, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(558, 1, 18, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(559, 1, 18, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(560, 1, 18, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(561, 1, 18, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(562, 1, 18, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(563, 1, 18, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(564, 1, 18, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(565, 1, 18, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(566, 1, 18, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(567, 1, 18, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(568, 1, 18, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(569, 1, 18, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(570, 1, 18, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(571, 1, 18, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(572, 1, 18, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(573, 1, 18, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(574, 1, 18, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(575, 1, 18, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(576, 1, 18, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(577, 1, 19, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(578, 1, 19, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(579, 1, 19, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(580, 1, 19, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(581, 1, 19, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(582, 1, 19, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(583, 1, 19, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(584, 1, 19, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(585, 1, 19, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(586, 1, 19, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(587, 1, 19, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(588, 1, 19, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(589, 1, 19, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(590, 1, 19, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(591, 1, 19, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(592, 1, 19, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(593, 1, 19, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(594, 1, 19, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(595, 1, 19, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(596, 1, 19, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(597, 1, 19, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(598, 1, 19, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(599, 1, 19, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(600, 1, 19, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(601, 1, 19, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(602, 1, 19, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(603, 1, 19, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(604, 1, 19, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(605, 1, 19, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(606, 1, 19, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(607, 1, 19, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(608, 1, 19, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(609, 1, 20, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(610, 1, 20, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(611, 1, 20, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(612, 1, 20, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(613, 1, 20, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(614, 1, 20, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(615, 1, 20, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(616, 1, 20, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(617, 1, 20, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(618, 1, 20, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(619, 1, 20, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(620, 1, 20, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(621, 1, 20, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(622, 1, 20, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(623, 1, 20, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(624, 1, 20, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(625, 1, 20, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(626, 1, 20, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(627, 1, 20, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(628, 1, 20, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(629, 1, 20, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(630, 1, 20, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(631, 1, 20, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(632, 1, 20, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(633, 1, 20, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(634, 1, 20, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(635, 1, 20, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(636, 1, 20, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(637, 1, 20, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(638, 1, 20, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(639, 1, 20, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(640, 1, 20, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(641, 1, 21, 86, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(642, 1, 21, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(643, 1, 21, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(644, 1, 21, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(645, 1, 21, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(646, 1, 21, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(647, 1, 21, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(648, 1, 21, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(649, 1, 21, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(650, 1, 21, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(651, 1, 21, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(652, 1, 21, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(653, 1, 21, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(654, 1, 21, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(655, 1, 21, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(656, 1, 21, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(657, 1, 21, 88, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(658, 1, 21, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(659, 1, 21, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(660, 1, 21, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(661, 1, 21, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(662, 1, 21, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(663, 1, 21, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(664, 1, 21, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(665, 1, 21, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(666, 1, 21, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(667, 1, 21, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(668, 1, 21, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(669, 1, 21, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(670, 1, 21, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(671, 1, 21, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(672, 1, 21, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(673, 1, 22, 86, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(674, 1, 22, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(675, 1, 22, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(676, 1, 22, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(677, 1, 22, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(678, 1, 22, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(679, 1, 22, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(680, 1, 22, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(681, 1, 22, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(682, 1, 22, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(683, 1, 22, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(684, 1, 22, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(685, 1, 22, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(686, 1, 22, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(687, 1, 22, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(688, 1, 22, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(689, 1, 22, 87, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(690, 1, 22, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(691, 1, 22, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(692, 1, 22, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(693, 1, 22, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(694, 1, 22, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(695, 1, 22, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(696, 1, 22, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(697, 1, 22, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(698, 1, 22, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(699, 1, 22, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(700, 1, 22, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(701, 1, 22, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(702, 1, 22, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(703, 1, 22, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(704, 1, 22, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(705, 1, 23, 79, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(706, 1, 23, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(707, 1, 23, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(708, 1, 23, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(709, 1, 23, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(710, 1, 23, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(711, 1, 23, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(712, 1, 23, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(713, 1, 23, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(714, 1, 23, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(715, 1, 23, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(716, 1, 23, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(717, 1, 23, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(718, 1, 23, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(719, 1, 23, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(720, 1, 23, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(721, 1, 23, 86, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(722, 1, 23, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(723, 1, 23, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(724, 1, 23, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(725, 1, 23, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(726, 1, 23, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(727, 1, 23, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(728, 1, 23, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(729, 1, 23, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', '');
INSERT INTO `table_grades` (`grade_id`, `sy_id`, `student_id`, `student_grade`, `grading_period_id`, `assignment_id`, `encode_date`, `encode_by`, `update_date`, `update_by`, `delete_date`, `delete_by`) VALUES
(730, 1, 23, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(731, 1, 23, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(732, 1, 23, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(733, 1, 23, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(734, 1, 23, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(735, 1, 23, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(736, 1, 23, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(737, 1, 24, 88, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(738, 1, 24, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(739, 1, 24, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(740, 1, 24, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(741, 1, 24, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(742, 1, 24, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(743, 1, 24, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(744, 1, 24, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(745, 1, 24, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(746, 1, 24, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(747, 1, 24, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(748, 1, 24, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(749, 1, 24, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(750, 1, 24, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(751, 1, 24, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(752, 1, 24, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(753, 1, 24, 90, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(754, 1, 24, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(755, 1, 24, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(756, 1, 24, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(757, 1, 24, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(758, 1, 24, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(759, 1, 24, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(760, 1, 24, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(761, 1, 24, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(762, 1, 24, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(763, 1, 24, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(764, 1, 24, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(765, 1, 24, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(766, 1, 24, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(767, 1, 24, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(768, 1, 24, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(769, 1, 25, 83, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(770, 1, 25, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(771, 1, 25, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(772, 1, 25, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(773, 1, 25, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(774, 1, 25, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(775, 1, 25, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(776, 1, 25, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(777, 1, 25, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(778, 1, 25, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(779, 1, 25, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(780, 1, 25, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(781, 1, 25, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(782, 1, 25, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(783, 1, 25, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(784, 1, 25, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(785, 1, 25, 81, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(786, 1, 25, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(787, 1, 25, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(788, 1, 25, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(789, 1, 25, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(790, 1, 25, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(791, 1, 25, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(792, 1, 25, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(793, 1, 25, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(794, 1, 25, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(795, 1, 25, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(796, 1, 25, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(797, 1, 25, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(798, 1, 25, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(799, 1, 25, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(800, 1, 25, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(801, 1, 26, 80, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(802, 1, 26, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(803, 1, 26, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(804, 1, 26, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(805, 1, 26, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(806, 1, 26, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(807, 1, 26, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(808, 1, 26, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(809, 1, 26, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(810, 1, 26, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(811, 1, 26, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(812, 1, 26, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(813, 1, 26, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(814, 1, 26, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(815, 1, 26, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(816, 1, 26, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(817, 1, 26, 78, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(818, 1, 26, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(819, 1, 26, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(820, 1, 26, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(821, 1, 26, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(822, 1, 26, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(823, 1, 26, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(824, 1, 26, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(825, 1, 26, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(826, 1, 26, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(827, 1, 26, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(828, 1, 26, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(829, 1, 26, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(830, 1, 26, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(831, 1, 26, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(832, 1, 26, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(833, 1, 27, 83, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(834, 1, 27, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(835, 1, 27, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(836, 1, 27, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(837, 1, 27, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(838, 1, 27, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(839, 1, 27, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(840, 1, 27, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(841, 1, 27, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(842, 1, 27, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(843, 1, 27, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(844, 1, 27, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(845, 1, 27, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(846, 1, 27, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(847, 1, 27, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(848, 1, 27, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(849, 1, 27, 88, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(850, 1, 27, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(851, 1, 27, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(852, 1, 27, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(853, 1, 27, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(854, 1, 27, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(855, 1, 27, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(856, 1, 27, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(857, 1, 27, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(858, 1, 27, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(859, 1, 27, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(860, 1, 27, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(861, 1, 27, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(862, 1, 27, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(863, 1, 27, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(864, 1, 27, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(865, 1, 28, 84, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(866, 1, 28, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(867, 1, 28, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(868, 1, 28, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(869, 1, 28, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(870, 1, 28, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(871, 1, 28, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(872, 1, 28, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(873, 1, 28, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(874, 1, 28, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(875, 1, 28, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(876, 1, 28, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(877, 1, 28, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(878, 1, 28, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(879, 1, 28, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(880, 1, 28, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(881, 1, 28, 77, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(882, 1, 28, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(883, 1, 28, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(884, 1, 28, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(885, 1, 28, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(886, 1, 28, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(887, 1, 28, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(888, 1, 28, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(889, 1, 28, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(890, 1, 28, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(891, 1, 28, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(892, 1, 28, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(893, 1, 28, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(894, 1, 28, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(895, 1, 28, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(896, 1, 28, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(897, 1, 29, 89, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(898, 1, 29, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(899, 1, 29, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(900, 1, 29, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(901, 1, 29, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(902, 1, 29, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(903, 1, 29, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(904, 1, 29, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(905, 1, 29, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(906, 1, 29, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(907, 1, 29, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(908, 1, 29, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(909, 1, 29, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(910, 1, 29, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(911, 1, 29, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(912, 1, 29, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(913, 1, 29, 86, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(914, 1, 29, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(915, 1, 29, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(916, 1, 29, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(917, 1, 29, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(918, 1, 29, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(919, 1, 29, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(920, 1, 29, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(921, 1, 29, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(922, 1, 29, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(923, 1, 29, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(924, 1, 29, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(925, 1, 29, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(926, 1, 29, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(927, 1, 29, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(928, 1, 29, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(929, 1, 30, 88, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(930, 1, 30, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(931, 1, 30, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(932, 1, 30, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(933, 1, 30, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(934, 1, 30, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(935, 1, 30, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(936, 1, 30, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(937, 1, 30, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(938, 1, 30, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(939, 1, 30, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(940, 1, 30, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(941, 1, 30, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(942, 1, 30, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(943, 1, 30, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(944, 1, 30, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(945, 1, 30, 82, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(946, 1, 30, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(947, 1, 30, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(948, 1, 30, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(949, 1, 30, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(950, 1, 30, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(951, 1, 30, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(952, 1, 30, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(953, 1, 30, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(954, 1, 30, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(955, 1, 30, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(956, 1, 30, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(957, 1, 30, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(958, 1, 30, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(959, 1, 30, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(960, 1, 30, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(961, 1, 31, 0, 1, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(962, 1, 31, 0, 2, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(963, 1, 31, 0, 3, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(964, 1, 31, 0, 4, 8, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(965, 1, 31, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:45:22 pm', '8', '', ''),
(966, 1, 31, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(967, 1, 31, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(968, 1, 31, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(969, 1, 31, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(970, 1, 31, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(971, 1, 31, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(972, 1, 31, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(973, 1, 31, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(974, 1, 31, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(975, 1, 31, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(976, 1, 31, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(977, 1, 31, 0, 1, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(978, 1, 31, 0, 2, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(979, 1, 31, 0, 3, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(980, 1, 31, 0, 4, 4, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(981, 1, 31, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(982, 1, 31, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(983, 1, 31, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(984, 1, 31, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(985, 1, 31, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(986, 1, 31, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(987, 1, 31, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(988, 1, 31, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(989, 1, 31, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(990, 1, 31, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(991, 1, 31, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(992, 1, 31, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(993, 1, 32, 86, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(994, 1, 32, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(995, 1, 32, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(996, 1, 32, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(997, 1, 32, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(998, 1, 32, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(999, 1, 32, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1000, 1, 32, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1001, 1, 32, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1002, 1, 32, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1003, 1, 32, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1004, 1, 32, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1005, 1, 32, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1006, 1, 32, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1007, 1, 32, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1008, 1, 32, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1009, 1, 32, 85, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(1010, 1, 32, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1011, 1, 32, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1012, 1, 32, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1013, 1, 32, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1014, 1, 32, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1015, 1, 32, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1016, 1, 32, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1017, 1, 32, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1018, 1, 32, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1019, 1, 32, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1020, 1, 32, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1021, 1, 32, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1022, 1, 32, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1023, 1, 32, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1024, 1, 32, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1025, 1, 33, 86, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(1026, 1, 33, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1027, 1, 33, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1028, 1, 33, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1029, 1, 33, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1030, 1, 33, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1031, 1, 33, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1032, 1, 33, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1033, 1, 33, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1034, 1, 33, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1035, 1, 33, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1036, 1, 33, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1037, 1, 33, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1038, 1, 33, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1039, 1, 33, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1040, 1, 33, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1041, 1, 33, 82, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(1042, 1, 33, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1043, 1, 33, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1044, 1, 33, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1045, 1, 33, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1046, 1, 33, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1047, 1, 33, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1048, 1, 33, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1049, 1, 33, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1050, 1, 33, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1051, 1, 33, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1052, 1, 33, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1053, 1, 33, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1054, 1, 33, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1055, 1, 33, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1056, 1, 33, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1057, 1, 34, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1058, 1, 34, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1059, 1, 34, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1060, 1, 34, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1061, 1, 34, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1062, 1, 34, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1063, 1, 34, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1064, 1, 34, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1065, 1, 34, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1066, 1, 34, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1067, 1, 34, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1068, 1, 34, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1069, 1, 34, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1070, 1, 34, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1071, 1, 34, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1072, 1, 34, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1073, 1, 34, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1074, 1, 34, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1075, 1, 34, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1076, 1, 34, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1077, 1, 34, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1078, 1, 34, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1079, 1, 34, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1080, 1, 34, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1081, 1, 34, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1082, 1, 34, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1083, 1, 34, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1084, 1, 34, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1085, 1, 34, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1086, 1, 34, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1087, 1, 34, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1088, 1, 34, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1089, 1, 35, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1090, 1, 35, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1091, 1, 35, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1092, 1, 35, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1093, 1, 35, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1094, 1, 35, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1095, 1, 35, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1096, 1, 35, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1097, 1, 35, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1098, 1, 35, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1099, 1, 35, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1100, 1, 35, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1101, 1, 35, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1102, 1, 35, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1103, 1, 35, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1104, 1, 35, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1105, 1, 35, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1106, 1, 35, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1107, 1, 35, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1108, 1, 35, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1109, 1, 35, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1110, 1, 35, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1111, 1, 35, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1112, 1, 35, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1113, 1, 35, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1114, 1, 35, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1115, 1, 35, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1116, 1, 35, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1117, 1, 35, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1118, 1, 35, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1119, 1, 35, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1120, 1, 35, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1121, 1, 36, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1122, 1, 36, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1123, 1, 36, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1124, 1, 36, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1125, 1, 36, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1126, 1, 36, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1127, 1, 36, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1128, 1, 36, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1129, 1, 36, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1130, 1, 36, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1131, 1, 36, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1132, 1, 36, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1133, 1, 36, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1134, 1, 36, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1135, 1, 36, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1136, 1, 36, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1137, 1, 36, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1138, 1, 36, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1139, 1, 36, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1140, 1, 36, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1141, 1, 36, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1142, 1, 36, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1143, 1, 36, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1144, 1, 36, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1145, 1, 36, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1146, 1, 36, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1147, 1, 36, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1148, 1, 36, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1149, 1, 36, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1150, 1, 36, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1151, 1, 36, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1152, 1, 36, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1153, 1, 37, 88, 1, 34, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:09 pm', '34', '', ''),
(1154, 1, 37, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1155, 1, 37, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1156, 1, 37, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1157, 1, 37, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1158, 1, 37, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1159, 1, 37, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1160, 1, 37, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1161, 1, 37, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1162, 1, 37, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1163, 1, 37, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1164, 1, 37, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1165, 1, 37, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1166, 1, 37, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1167, 1, 37, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1168, 1, 37, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1169, 1, 37, 81, 1, 1, '01/01/0001 12:00:00 am', '1', '20/06/2020 8:47:38 pm', '34', '', ''),
(1170, 1, 37, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1171, 1, 37, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1172, 1, 37, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1173, 1, 37, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1174, 1, 37, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1175, 1, 37, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1176, 1, 37, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1177, 1, 37, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1178, 1, 37, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1179, 1, 37, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1180, 1, 37, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1181, 1, 37, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1182, 1, 37, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1183, 1, 37, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1184, 1, 37, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1185, 1, 38, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1186, 1, 38, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1187, 1, 38, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1188, 1, 38, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1189, 1, 38, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1190, 1, 38, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1191, 1, 38, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1192, 1, 38, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1193, 1, 38, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1194, 1, 38, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1195, 1, 38, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1196, 1, 38, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1197, 1, 38, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1198, 1, 38, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1199, 1, 38, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1200, 1, 38, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1201, 1, 38, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1202, 1, 38, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1203, 1, 38, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1204, 1, 38, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1205, 1, 38, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1206, 1, 38, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1207, 1, 38, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1208, 1, 38, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1209, 1, 38, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1210, 1, 38, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1211, 1, 38, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1212, 1, 38, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1213, 1, 38, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1214, 1, 38, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1215, 1, 38, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1216, 1, 38, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1217, 1, 39, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1218, 1, 39, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1219, 1, 39, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1220, 1, 39, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1221, 1, 39, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1222, 1, 39, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1223, 1, 39, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1224, 1, 39, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1225, 1, 39, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1226, 1, 39, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1227, 1, 39, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1228, 1, 39, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1229, 1, 39, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1230, 1, 39, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1231, 1, 39, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1232, 1, 39, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1233, 1, 39, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1234, 1, 39, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1235, 1, 39, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1236, 1, 39, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1237, 1, 39, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1238, 1, 39, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1239, 1, 39, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1240, 1, 39, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1241, 1, 39, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1242, 1, 39, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1243, 1, 39, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1244, 1, 39, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1245, 1, 39, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1246, 1, 39, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1247, 1, 39, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1248, 1, 39, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1249, 1, 40, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1250, 1, 40, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1251, 1, 40, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1252, 1, 40, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1253, 1, 40, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1254, 1, 40, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1255, 1, 40, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1256, 1, 40, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1257, 1, 40, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1258, 1, 40, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1259, 1, 40, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1260, 1, 40, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1261, 1, 40, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1262, 1, 40, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1263, 1, 40, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1264, 1, 40, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1265, 1, 40, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1266, 1, 40, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1267, 1, 40, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1268, 1, 40, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1269, 1, 40, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1270, 1, 40, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1271, 1, 40, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1272, 1, 40, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1273, 1, 40, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1274, 1, 40, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1275, 1, 40, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1276, 1, 40, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1277, 1, 40, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1278, 1, 40, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1279, 1, 40, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1280, 1, 40, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1281, 1, 41, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1282, 1, 41, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1283, 1, 41, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1284, 1, 41, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1285, 1, 41, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1286, 1, 41, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1287, 1, 41, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1288, 1, 41, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1289, 1, 41, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1290, 1, 41, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1291, 1, 41, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1292, 1, 41, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1293, 1, 41, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1294, 1, 41, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1295, 1, 41, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1296, 1, 41, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1297, 1, 41, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1298, 1, 41, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1299, 1, 41, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1300, 1, 41, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1301, 1, 41, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1302, 1, 41, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1303, 1, 41, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1304, 1, 41, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1305, 1, 41, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1306, 1, 41, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1307, 1, 41, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1308, 1, 41, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1309, 1, 41, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1310, 1, 41, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1311, 1, 41, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1312, 1, 41, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1313, 1, 42, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1314, 1, 42, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1315, 1, 42, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1316, 1, 42, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1317, 1, 42, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1318, 1, 42, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1319, 1, 42, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1320, 1, 42, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1321, 1, 42, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1322, 1, 42, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1323, 1, 42, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1324, 1, 42, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1325, 1, 42, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1326, 1, 42, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1327, 1, 42, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1328, 1, 42, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1329, 1, 42, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1330, 1, 42, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1331, 1, 42, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1332, 1, 42, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1333, 1, 42, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1334, 1, 42, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1335, 1, 42, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1336, 1, 42, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1337, 1, 42, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1338, 1, 42, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1339, 1, 42, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1340, 1, 42, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1341, 1, 42, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1342, 1, 42, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1343, 1, 42, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1344, 1, 42, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1345, 1, 43, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1346, 1, 43, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1347, 1, 43, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1348, 1, 43, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1349, 1, 43, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1350, 1, 43, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1351, 1, 43, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1352, 1, 43, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1353, 1, 43, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1354, 1, 43, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1355, 1, 43, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1356, 1, 43, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1357, 1, 43, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1358, 1, 43, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1359, 1, 43, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1360, 1, 43, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1361, 1, 43, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1362, 1, 43, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1363, 1, 43, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1364, 1, 43, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1365, 1, 43, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1366, 1, 43, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1367, 1, 43, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1368, 1, 43, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1369, 1, 43, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1370, 1, 43, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1371, 1, 43, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1372, 1, 43, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1373, 1, 43, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1374, 1, 43, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1375, 1, 43, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1376, 1, 43, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1377, 1, 44, 0, 1, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1378, 1, 44, 0, 2, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1379, 1, 44, 0, 3, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1380, 1, 44, 0, 4, 5, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1381, 1, 44, 0, 1, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1382, 1, 44, 0, 2, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1383, 1, 44, 0, 3, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1384, 1, 44, 0, 4, 7, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1385, 1, 44, 0, 1, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1386, 1, 44, 0, 2, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1387, 1, 44, 0, 3, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1388, 1, 44, 0, 4, 1, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1389, 1, 44, 0, 1, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1390, 1, 44, 0, 2, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1391, 1, 44, 0, 3, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1392, 1, 44, 0, 4, 33, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1393, 1, 44, 0, 1, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1394, 1, 44, 0, 2, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1395, 1, 44, 0, 3, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1396, 1, 44, 0, 4, 3, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1397, 1, 44, 0, 1, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1398, 1, 44, 0, 2, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1399, 1, 44, 0, 3, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1400, 1, 44, 0, 4, 2, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1401, 1, 44, 0, 1, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1402, 1, 44, 0, 2, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1403, 1, 44, 0, 3, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1404, 1, 44, 0, 4, 6, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1405, 1, 44, 0, 1, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1406, 1, 44, 0, 2, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1407, 1, 44, 0, 3, 34, '01/01/0001 12:00:00 am', '1', '', '', '', ''),
(1408, 1, 44, 0, 4, 34, '01/01/0001 12:00:00 am', '1', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `table_grade_encoding`
--

CREATE TABLE `table_grade_encoding` (
  `encoding_id` int(11) NOT NULL,
  `start_date` text NOT NULL,
  `end_date` text NOT NULL,
  `grading_period_id` int(11) NOT NULL,
  `sy_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_grade_encoding`
--

INSERT INTO `table_grade_encoding` (`encoding_id`, `start_date`, `end_date`, `grading_period_id`, `sy_id`) VALUES
(1, '20/06/2020 6:16:08 pm', '21/06/2020 6:16:08 pm', 1, 1),
(2, '01/01/0001 12:00:00 am', '21/06/2020 8:42:29 pm', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `table_grade_level`
--

CREATE TABLE `table_grade_level` (
  `grade_level_id` int(11) NOT NULL,
  `grade_level` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_grade_level`
--

INSERT INTO `table_grade_level` (`grade_level_id`, `grade_level`) VALUES
(1, 'Grade 7'),
(2, 'Grade 8'),
(3, 'Grade 9'),
(4, 'Grade 10');

-- --------------------------------------------------------

--
-- Table structure for table `table_grading_period`
--

CREATE TABLE `table_grading_period` (
  `grading_period_id` int(11) NOT NULL,
  `grading_period` varchar(32) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_grading_period`
--

INSERT INTO `table_grading_period` (`grading_period_id`, `grading_period`, `status`) VALUES
(1, '1st', 0),
(2, '2nd', 1),
(3, '3rd', 0),
(4, '4th', 0);

-- --------------------------------------------------------

--
-- Table structure for table `table_guardian`
--

CREATE TABLE `table_guardian` (
  `guardian_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `student_no` varchar(100) NOT NULL,
  `relationship_id` int(32) NOT NULL,
  `relationship` varchar(32) NOT NULL,
  `guardian_name` varchar(1000) NOT NULL,
  `occupation` varchar(32) NOT NULL,
  `contact` varchar(32) NOT NULL,
  `city_address` varchar(32) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_guardian_relationship`
--

CREATE TABLE `table_guardian_relationship` (
  `relationship_id` int(11) NOT NULL,
  `relationship` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_guardian_relationship`
--

INSERT INTO `table_guardian_relationship` (`relationship_id`, `relationship`) VALUES
(1, 'father'),
(2, 'mother'),
(3, 'guardian');

-- --------------------------------------------------------

--
-- Table structure for table `table_level_schedule`
--

CREATE TABLE `table_level_schedule` (
  `level_schedule_id` int(11) NOT NULL,
  `schedule` varchar(32) NOT NULL,
  `grade_level_id` int(11) NOT NULL,
  `is_active` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_level_schedule`
--

INSERT INTO `table_level_schedule` (`level_schedule_id`, `schedule`, `grade_level_id`, `is_active`) VALUES
(1, '6:20a-12:50p', 1, 1),
(2, '6:20a-12:50p', 2, 1),
(3, '1:00p-7:30p', 3, 1),
(4, '1:00p-7:30p', 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `table_level_section`
--

CREATE TABLE `table_level_section` (
  `level_section_id` int(11) NOT NULL,
  `grade_level_id` int(11) NOT NULL,
  `section` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_level_section`
--

INSERT INTO `table_level_section` (`level_section_id`, `grade_level_id`, `section`) VALUES
(1, 1, 'SPJ 7'),
(2, 1, 'GEMINI'),
(3, 1, 'VIRGO'),
(4, 1, 'TAURUS'),
(5, 1, 'CAPRICORN'),
(6, 1, 'AQUARIUS'),
(7, 1, 'PISCES'),
(8, 1, 'SCORPO'),
(9, 1, 'SAGITTARIUS'),
(10, 1, 'LEO'),
(11, 1, 'LIBRA'),
(12, 1, 'SPED 7'),
(13, 2, 'SPJ 8'),
(14, 2, 'WISDOM'),
(15, 2, 'LOVE'),
(16, 2, 'HOPE'),
(17, 2, 'CHARITY'),
(18, 2, 'FAITH'),
(19, 2, 'BENEVOLENCE'),
(20, 2, 'JOY'),
(21, 2, 'PEACE'),
(22, 2, 'CHASTITY'),
(23, 2, 'GENEROSITY'),
(24, 2, 'SPED 8'),
(25, 3, 'SPJ 9'),
(26, 3, 'EINSTEIN'),
(27, 3, 'ARISTOTLE'),
(28, 3, 'EUCLID'),
(29, 3, 'NEWTON'),
(30, 3, 'ARCHIMEDES'),
(31, 3, 'PASCAL'),
(32, 3, 'PLATO'),
(33, 3, 'PHYTHAGORAS'),
(34, 3, 'GALILEI'),
(35, 3, 'COPERNICUS'),
(36, 3, 'SPED 9'),
(37, 4, 'SPJ 10'),
(38, 4, 'SHAKESPEARE'),
(39, 4, 'TWAIN'),
(40, 4, 'MORRISON'),
(41, 4, 'THOMAS'),
(42, 4, 'BRONTE'),
(43, 4, 'HEMINGWAY'),
(44, 4, 'GOLDING'),
(45, 4, 'HUGO'),
(46, 4, 'JAMES'),
(47, 4, 'KIPLING'),
(48, 4, 'SPED 10');

-- --------------------------------------------------------

--
-- Table structure for table `table_module`
--

CREATE TABLE `table_module` (
  `module_id` int(11) NOT NULL,
  `module` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_module`
--

INSERT INTO `table_module` (`module_id`, `module`) VALUES
(1, 'enrollment'),
(2, 'student'),
(3, 'scheduling'),
(4, 'grading');

-- --------------------------------------------------------

--
-- Table structure for table `table_position`
--

CREATE TABLE `table_position` (
  `position_id` int(11) NOT NULL,
  `position` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_position`
--

INSERT INTO `table_position` (`position_id`, `position`) VALUES
(1, 'Records In-Charge'),
(2, 'Grade Level Chairman'),
(3, 'Class Adviser');

-- --------------------------------------------------------

--
-- Table structure for table `table_room`
--

CREATE TABLE `table_room` (
  `room_id` int(11) NOT NULL,
  `room_no` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_school_history`
--

CREATE TABLE `table_school_history` (
  `history_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `school_name` int(11) NOT NULL,
  `school_level` int(11) NOT NULL,
  `year_entry` int(11) NOT NULL,
  `year_exit` int(11) NOT NULL,
  `school_address` varchar(32) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_settings`
--

CREATE TABLE `table_settings` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `table_settings`
--

INSERT INTO `table_settings` (`id`, `name`, `description`) VALUES
(1, 'Mission', 'To protect and promote the right of every Filipino to quality, equitable, culture-based, and complete basic education where:\r\n\r\nStudents learn in a child-friendly, gender-sensitive, safe, and motivating environment.aaaa\r\n\r\nTeachers facilitate learning and constantly nurture every learner.\r\n\r\nAdministrators and staff, as stewards of the institution, ensure an enabling and supportive environment for effective learning to happen.\r\n\r\nFamily, community, and other stakeholders are actively engaged and share responsibility for developing life-long learners.'),
(2, 'Core Values', 'Maka-Diyos\r\n\r\nMaka-tao\r\n\r\nMakakalikasan\r\n\r\nMakabansa aA'),
(3, 'Vision', 'We dream of Filipinos \r\n\r\nwho passionately love their country \r\n\r\nand whose values and competencies  \r\n\r\nenable them to realize their full potential \r\n\r\nand contribute meaningfully to building the nation.\r\n\r\nAs a learner-centered public institution, \r\n\r\nthe Department of Education \r\n\r\ncontinuously improves itself '),
(4, 'School Name', 'Eulogio Rodriguez Integrated School'),
(5, 'School Code', '500333'),
(6, 'Tel No', '531-7869 / 236-4602'),
(7, 'Address', '670 Cavo F. Sanchez, Manila, Metro Manila'),
(8, 'Principal', 'Mr. Romeo E. Bandal (Principal IV)');

-- --------------------------------------------------------

--
-- Table structure for table `table_students`
--

CREATE TABLE `table_students` (
  `student_id` int(11) NOT NULL,
  `student_no` varchar(32) NOT NULL,
  `file_status` int(11) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `middle_name` varchar(32) NOT NULL,
  `date_of_birth` varchar(32) NOT NULL,
  `sex` varchar(11) NOT NULL,
  `form9` int(11) NOT NULL,
  `form10` int(11) NOT NULL,
  `psa` int(11) NOT NULL,
  `good_moral` int(11) NOT NULL,
  `house_no` int(100) NOT NULL,
  `street` varchar(60) NOT NULL,
  `barangay` varchar(60) NOT NULL,
  `zip` varchar(20) NOT NULL,
  `city` varchar(20) NOT NULL,
  `creation_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `update_date` varchar(32) NOT NULL,
  `update_by` varchar(32) NOT NULL,
  `enrolled_date` varchar(32) NOT NULL,
  `enrolled_by` varchar(32) NOT NULL,
  `age` int(100) NOT NULL,
  `father_name` varchar(100) NOT NULL,
  `father_occupation` varchar(100) NOT NULL,
  `father_mobile` varchar(100) NOT NULL,
  `mother_name` varchar(100) NOT NULL,
  `mother_occupation` varchar(100) NOT NULL,
  `mother_mobile` varchar(100) NOT NULL,
  `guardian_name` varchar(100) NOT NULL,
  `guardian_occupation` varchar(100) NOT NULL,
  `guardian_mobile` varchar(100) NOT NULL,
  `last_grade` varchar(50) NOT NULL,
  `last_school` varchar(50) NOT NULL,
  `last_school_address` varchar(50) NOT NULL,
  `last_sy` varchar(50) NOT NULL,
  `last_school_id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_students`
--

INSERT INTO `table_students` (`student_id`, `student_no`, `file_status`, `last_name`, `first_name`, `middle_name`, `date_of_birth`, `sex`, `form9`, `form10`, `psa`, `good_moral`, `house_no`, `street`, `barangay`, `zip`, `city`, `creation_date`, `created_by`, `update_date`, `update_by`, `enrolled_date`, `enrolled_by`, `age`, `father_name`, `father_occupation`, `father_mobile`, `mother_name`, `mother_occupation`, `mother_mobile`, `guardian_name`, `guardian_occupation`, `guardian_mobile`, `last_grade`, `last_school`, `last_school_address`, `last_sy`, `last_school_id`) VALUES
(1, '2015-10000', 0, 'Julian', 'Silvestre', 'Amoldo', '20/02/2010', 'Male', 1, 1, 1, 1, 23, 'n/a', 'Barangay 27 ', '1012', 'Manila', '', '', '', '', '', '', 10, 'Laurindas Silvestre ', '09088394832', 'Doctor', 'Carleigha  Silvestre', 'Engineer', '09038493923', '', '', '', '', '', '', '', ''),
(2, '2015-10001', 0, 'Ariel', 'Mike', 'Emanual', '08/06/2009', 'Male', 1, 1, 1, 1, 10051, 'Bonifacio', 'Barangay 25 ', '1012', 'Manila', '', '', '', '', '', '', 11, ' MikeAriel', '9088917626', 'Online Seller', ' Ebrahim,Ariel', 'Business Man,', '9982748294', '', '', '', '', '', '', '', ''),
(3, '2015-10002', 0, 'Sam', ' Tracey', ' Koli', '20/02/2010', 'Male', 0, 0, 1, 1, 10052, 'MAsipag', 'Barangay 21 ', '1012', 'Manila', '', '', '', '', '', '', 10, '  RathbunSam', '9088917627', 'None', ' JohnSam', 'Online Seller', '9982748295', '', '', '', '', '', '', '', ''),
(4, '2015-10003', 0, ' Prime', 'Mahesh', 'John', '20/02/2010', 'Male', 0, 0, 1, 1, 10053, 'Blk 89,', 'Barangka Ibaba', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Raj Prime', '9088917628', 'Office Clerk,', ' Mike Prime', 'Call Center Agent', '9982748296', '', '', '', '', '', '', '', ''),
(5, '2015-10004', 0, 'Bartolome', ' Rathbun', 'Emanual', '20/02/2010', 'Male', 1, 1, 1, 1, 10054, 'Road 2', 'Barangay 26 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' AllenBartolome', '9088917629', 'Online Seller', ' SalmaBartolome', 'Call Center Agent', '9982748297', '', '', '', '', '', '', '', ''),
(6, '2015-10005', 0, 'Beck', ' Prime', 'Karina', '20/02/2010', 'Female', 0, 0, 1, 1, 10055, 'Mayon', 'Barangay 26 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' MaheshBeck', '9088917630', 'Engineer', '  StaceyBeck', 'Doctor', '9982748298', '', '', '', '', '', '', '', ''),
(7, '2015-10006', 0, 'Jimmy', ' Tracey', ' Stacey', '20/02/2010', 'Female', 1, 1, 1, 1, 10056, 'Road 2', 'Barangay 24 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' McCarterJimmy', '9088917631', 'Business Man,', ' LauzonJimmy', 'Accountant', '9982748299', '', '', '', '', '', '', '', ''),
(8, '2015-10007', 0, 'Morissa', ' Prime', 'Salma', '20/02/2010', 'Female', 0, 0, 1, 1, 10057, 'Kawani', 'Barangay 26 ', '1012', 'Manila', '', '', '', '', '', '', 10, '  TraceyMorissa', '9088917632', 'Call Center Agent', ' Ebrahim,Morissa', 'Call Center Agent', '9982748300', '', '', '', '', '', '', '', ''),
(9, '2015-10008', 0, 'Bartolome', 'Dave', ' Yesuahuah', '20/02/2010', 'Male', 0, 0, 1, 1, 10058, 'Street 1', 'Barangay 21 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' HenryBartolome', '9088917633', 'None', ' LauzonBartolome', 'Accountant', '9982748301', '', '', '', '', '', '', '', ''),
(10, '2015-10009', 0, 'Henry', 'Vince', 'Lauzon', '20/02/2010', 'Male', 1, 1, 1, 1, 10059, 'Rizal,', 'Barangay 3 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' MikeHenry', '9088917634', 'Online Seller', ' ElijahHenry', 'Office Clerk,', '9982748302', '', '', '', '', '', '', '', ''),
(11, '2015-10010', 0, 'Beck', 'Mark', 'Karina', '20/02/2010', 'Male', 0, 0, 1, 1, 10060, ' Posadas', 'Barangay 21 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' MaheshBeck', '9088917635', 'Online Seller', '  YesuahuahBeck', 'Call Center Agent', '9982748303', '', '', '', '', '', '', '', ''),
(12, '2015-10011', 0, 'Buenaflor', ' Rathbun', ' Koli', '20/02/2010', 'Male', 1, 1, 1, 1, 10061, 'Blk 89,', 'Calzada', '1630', 'Taguig', '', '', '', '', '', '', 10, ' AllenBuenaflor', '9088917636', 'Engineer', ' Ebrahim,Buenaflor', 'Doctor', '9982748304', '', '', '', '', '', '', '', ''),
(13, '2015-10012', 0, 'Jimmy', ' Prime', 'Basan', '20/02/2010', 'Female', 1, 1, 1, 1, 10062, 'Mayon', 'Barangka Ibaba', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' AllenJimmy', '9088917637', 'Office Clerk,', '  StaceyJimmy', 'Office Clerk,', '9982748305', '', '', '', '', '', '', '', ''),
(14, '2015-10013', 0, 'Urbano', 'Monica', 'Lauzon', '20/02/2010', 'Female', 0, 0, 1, 1, 10063, 'Street 1', 'Greenhills South', '1556', 'Mandaluyong', '', '', '', '', '', '', 10, ' KhufraUrbano', '9088917638', 'Office Clerk,', ' BasanUrbano', 'Engineer', '9982748306', '', '', '', '', '', '', '', ''),
(15, '2015-10014', 0, 'Jimmy', 'Rica', 'Mike', '20/02/2010', 'Female', 0, 0, 1, 1, 10064, 'Road 3', 'Barangay 27 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' MonicaJimmy', '9088917639', 'None', '  StaceyJimmy', 'Call Center Agent', '9982748307', '', '', '', '', '', '', '', ''),
(16, '2015-10015', 0, 'Urbano', 'Mark', 'Karina', '20/02/2010', 'Male', 1, 1, 1, 1, 10065, 'MAsipag', 'Calzada', '1630', 'Taguig', '', '', '', '', '', '', 10, '  Tracey Urbano', '9088917640', 'Doctor', ' Ebrahim, Urbano', 'Online Seller', '9982748308', '', '', '', '', '', '', '', ''),
(17, '2015-10016', 0, 'Beck', 'Joana', ' Britney', '20/02/2010', 'Female', 1, 1, 1, 1, 10066, 'Mayon', 'Greenhills South', '1556', 'Mandaluyong', '', '', '', '', '', '', 10, '  Rathbun Beck', '9088917641', 'Engineer', ' Alina Beck', 'Business Man,', '9982748309', '', '', '', '', '', '', '', ''),
(18, '2015-10017', 0, 'Jimmy', 'Byron', 'Karina', '20/02/2010', 'Male', 1, 1, 1, 1, 10067, 'Road 3', 'Barangay 22 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Jeff Jimmy', '9088917642', 'Business Man,', ' Mike Jimmy', 'None', '9982748310', '', '', '', '', '', '', '', ''),
(19, '2015-10018', 0, 'Emely', 'Rose', 'Salma', '20/02/2010', 'Female', 0, 0, 1, 1, 10068, 'Karina', 'Barangka Ilaya', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, '  Rathbun Emely', '9088917643', 'None', ' Lauzon Emely', 'Doctor', '9982748311', '', '', '', '', '', '', '', ''),
(20, '2015-10019', 0, ' Jane', ' Rathbun', 'Cañada', '20/02/2010', 'Male', 1, 1, 1, 1, 10069, 'Kawani', 'Western Bicutan', '1630', 'Taguig', '', '', '', '', '', '', 10, ' Kilpa  Jane', '9088917644', 'Accountant', ' Lauzon  Jane', 'Business Man,', '9982748312', '', '', '', '', '', '', '', ''),
(21, '2015-10020', 0, 'Sam', 'Henry', 'Rose', '20/02/2010', 'Male', 1, 1, 1, 1, 10070, 'Road 3', 'Barangay 3 ', '1012', 'Manila', '', '', '', '', '', '', 10, '  Rathbun Sam', '9088917645', 'Business Man,', ' Ebrahim, Sam', 'Online Seller', '9982748313', '', '', '', '', '', '', '', ''),
(22, '2015-10021', 0, 'Bartolome', 'Joana', 'Alina', '20/02/2010', 'Male', 0, 0, 0, 1, 10071, 'Road 1', 'Barangay 21 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Prosise Bartolome', '9088917646', 'Call Center Agent', ' Maj Bartolome', 'Business Man,', '9982748314', '', '', '', '', '', '', '', ''),
(23, '2015-10022', 0, 'Buenaflor', 'Faith', 'Salma', '20/02/2010', 'Male', 1, 1, 1, 1, 10072, 'Kawani', 'Barangay 3 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Kilpa Buenaflor', '9088917647', 'Online Seller', ' Alina Buenaflor', 'Engineer', '9982748315', '', '', '', '', '', '', '', ''),
(24, '2015-10023', 0, 'Morissa', 'Joy', 'Cañada', '20/02/2010', 'Male', 1, 1, 1, 1, 10073, 'MAsipag', 'Western Bicutan', '1630', 'Taguig', '', '', '', '', '', '', 10, ' Prosise Morissa', '9088917648', 'Doctor', ' John Morissa', 'Engineer', '9982748316', '', '', '', '', '', '', '', ''),
(25, '2015-10024', 0, 'Bartolome', 'Henry', 'Elijah', '20/02/2010', 'Female', 1, 1, 1, 1, 10074, 'Road 3', 'Calzada', '1630', 'Taguig', '', '', '', '', '', '', 10, ' Jeff Bartolome', '9088917649', 'Call Center Agent', ' Abram, Bartolome', 'Online Seller', '9982748317', '', '', '', '', '', '', '', ''),
(26, '2015-10025', 0, 'Ariel', 'Byron', 'Basan', '20/02/2010', 'Female', 0, 0, 1, 1, 10075, ' Samapguita', 'Barangka Ilaya', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Rose Ariel', '9088917650', 'Engineer', ' Ebrahim, Ariel', 'None', '9982748318', '', '', '', '', '', '', '', ''),
(27, '2015-10026', 0, 'Urbano', 'Rose', 'Rose', '20/02/2010', 'Female', 1, 1, 1, 1, 10076, 'Road 1', 'Barangay 22 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Kilpa Urbano', '9088917651', 'Business Man,', ' Basan Urbano', 'Online Seller', '9982748319', '', '', '', '', '', '', '', ''),
(28, '2015-10027', 0, ' Prime', 'Allen', 'Elijah', '20/02/2010', 'Male', 1, 1, 1, 1, 10077, 'Karina', 'New Lower Bicutan', '1630', 'Taguig', '', '', '', '', '', '', 10, '  Tracey  Prime', '9088917652', 'Call Center Agent', ' Alina  Prime', 'Business Man,', '9982748320', '', '', '', '', '', '', '', ''),
(29, '2015-10028', 0, 'Manalo', 'Vince', 'Karina', '13/06/2006', 'Male', 0, 0, 1, 1, 10078, 'Bonifacio', 'Barangay 4 ', '1012', 'Manila', '', '', '', '', '', '', 14, ' Charles Manalo', '9088917653', 'Call Center Agent', '  Britney Manalo', 'Doctor', '9982748321', '', '', '', '', '', '', '', ''),
(30, '2015-10029', 0, 'Francisco', 'Monica', 'Lauzon', '20/02/2010', 'Female', 0, 0, 1, 1, 10079, 'Kalachuchi', 'Barangay 28 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Khufra Francisco', '9088917654', 'Online Seller', ' Abram, Francisco', 'Doctor', '9982748322', '', '', '', '', '', '', '', ''),
(31, '2015-10030', 0, 'Buendia', 'McCarter', 'Basan', '20/02/2010', 'Female', 1, 1, 1, 1, 10080, 'Kalachuchi', 'Barangay 27 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Harry Buendia', '9088917655', 'Accountant', ' Cañada Buendia', 'Doctor', '9982748323', '', '', '', '', '', '', '', ''),
(32, '2015-10031', 0, 'Laurino', 'Monica', 'Rose', '20/02/2010', 'Female', 0, 0, 1, 1, 10081, 'Karina', 'Barangay 3 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Claudine Laurino', '9088917656', 'Accountant', ' Maj Laurino', 'Doctor', '9982748324', '', '', '', '', '', '', '', ''),
(33, '2015-10032', 0, 'Jaudian', 'McCarter', ' Koli', '20/02/2010', 'Male', 0, 0, 1, 1, 10082, 'Rizal,', 'Mabini-J. Rizal', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Michale Jaudian', '9088917657', 'Office Clerk,', ' Basan Jaudian', 'Call Center Agent', '9982748325', '', '', '', '', '', '', '', ''),
(34, '2015-10033', 0, 'Santos', ' Kumar', 'Ebrahim,', '20/02/2010', 'Male', 1, 1, 1, 1, 10083, 'Road 2', 'Barangay 27 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Beth Santos', '9088917658', 'Business Man,', ' John Santos', 'Online Seller', '9982748326', '', '', '', '', '', '', '', ''),
(35, '2015-10034', 0, 'Laurino', 'Rica', 'Ebrahim,', '20/02/2010', 'Male', 0, 0, 0, 0, 10084, 'Road 2', 'Burol', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Claudine Laurino', '9088917659', 'Accountant', ' Elijah Laurino', 'Office Clerk,', '9982748327', '', '', '', '', '', '', '', ''),
(36, '2015-10035', 0, 'Jaudian', 'Mark', 'Elijah', '20/02/2010', 'Male', 0, 0, 1, 1, 10085, ' Blk 982', 'Barangay 27 ', '1012', 'Manila', '', '', '', '', '', '', 10, '  Rathbun Jaudian', '9088917660', 'Online Seller', ' Alina Jaudian', 'Online Seller', '9982748328', '', '', '', '', '', '', '', ''),
(37, '2015-10036', 0, 'Katigbak', 'Henry', 'Alina', '20/02/2010', 'Male', 0, 0, 1, 1, 10086, 'Kalachuchi', 'Barangay 22 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Beth Katigbak', '9088917661', 'Call Center Agent', '  Koli Katigbak', 'Accountant', '9982748329', '', '', '', '', '', '', '', ''),
(38, '2015-10037', 0, 'Laurino', 'Vince', 'Lauzon', '20/02/2010', 'Male', 0, 0, 1, 1, 10087, 'Road 1', 'Barangka Ibaba', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Kilpa Laurino', '9088917662', 'Doctor', ' Abram, Laurino', 'Office Clerk,', '9982748330', '', '', '', '', '', '', '', ''),
(39, '2015-10038', 0, 'Katigbak', 'Faith', 'Elijah', '20/02/2010', 'Female', 0, 0, 0, 0, 10088, 'Bonifacio', 'Barangay 3 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Betina Katigbak', '9088917663', 'Office Clerk,', ' Maj Katigbak', 'Doctor', '9982748331', '', '', '', '', '', '', '', ''),
(40, '2015-10039', 0, 'Buendia', 'Rose', 'Basan', '20/02/2010', 'Female', 0, 0, 1, 1, 10089, 'Kawani', 'Western Bicutan', '1630', 'Taguig', '', '', '', '', '', '', 10, ' Claudine Buendia', '9088917664', 'None', ' Basan Buendia', 'Business Man,', '9982748332', '', '', '', '', '', '', '', ''),
(41, '2015-10040', 0, 'Buendia', 'Henry', 'Alina', '20/02/2010', 'Female', 1, 1, 1, 1, 10090, ' Posadas', 'Harapin Ang Bukas', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Betina Buendia', '9088917665', 'Call Center Agent', ' Elijah Buendia', 'None', '9982748333', '', '', '', '', '', '', '', ''),
(42, '2015-10041', 0, ' Buenconsejo', 'Allen', ' Koli', '20/02/2010', 'Female', 1, 1, 1, 1, 10091, ' Samapguita', 'Barangay 22 ', '1012', 'Manila', '', '', '', '', '', '', 10, ' Richard  Buenconsejo', '9088917666', 'Business Man,', ' Maj  Buenconsejo', 'Accountant', '9982748334', '', '', '', '', '', '', '', ''),
(43, '2015-10042', 0, 'Francisco', 'Faith', 'Maj', '20/02/2010', 'Male', 1, 1, 1, 1, 10092, 'Rizal,', 'Barangka Ilaya', '1550', 'Mandaluyong', '', '', '', '', '', '', 10, ' Betina Francisco', '9088917667', 'Call Center Agent', ' Maj Francisco', 'Accountant', '9982748335', '', '', '', '', '', '', '', ''),
(44, '2015-10043', 0, 'Santos', ' John', 'Rose', '20/02/2010', 'Male', 0, 0, 1, 1, 10093, ' Posadas', 'Calzada', '1630', 'Taguig', '', '', '', '', '', '', 10, '  Popol Santos', '9088917668', 'Business Man,', ' Elijah Santos', 'Accountant', '9982748336', '', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `table_student_status`
--

CREATE TABLE `table_student_status` (
  `status_id` int(11) NOT NULL,
  `status` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_student_status`
--

INSERT INTO `table_student_status` (`status_id`, `status`) VALUES
(1, 'fail'),
(2, 'pass'),
(3, 'conditional');

-- --------------------------------------------------------

--
-- Table structure for table `table_subject`
--

CREATE TABLE `table_subject` (
  `subject_id` int(11) NOT NULL,
  `subject` varchar(32) NOT NULL,
  `frequency` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_subject`
--

INSERT INTO `table_subject` (`subject_id`, `subject`, `frequency`) VALUES
(1, 'Homeroom', 1),
(2, 'MAPEH', 4),
(3, 'Science', 4),
(4, 'AP', 4),
(5, 'English', 4),
(6, 'Filipino', 4),
(7, 'Math', 4),
(8, 'ESP', 1),
(9, 'TLE', 4);

-- --------------------------------------------------------

--
-- Table structure for table `table_subject_assignment`
--

CREATE TABLE `table_subject_assignment` (
  `assignment_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `grade_level_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_subject_assignment`
--

INSERT INTO `table_subject_assignment` (`assignment_id`, `subject_id`, `teacher_id`, `grade_level_id`) VALUES
(1, 3, 1, 1),
(2, 4, 2, 1),
(3, 5, 3, 1),
(4, 6, 4, 1),
(5, 7, 5, 1),
(6, 8, 6, 1),
(7, 9, 7, 1),
(8, 2, 8, 1),
(9, 8, 9, 2),
(10, 7, 10, 2),
(11, 6, 11, 2),
(12, 5, 12, 2),
(13, 4, 13, 2),
(14, 4, 14, 2),
(15, 3, 15, 2),
(16, 2, 16, 2),
(17, 9, 17, 3),
(18, 8, 18, 3),
(19, 7, 19, 3),
(20, 6, 20, 3),
(21, 5, 21, 3),
(22, 4, 22, 3),
(23, 3, 23, 3),
(24, 2, 24, 3),
(25, 9, 25, 4),
(26, 8, 26, 4),
(27, 7, 27, 4),
(28, 6, 28, 4),
(29, 5, 29, 4),
(30, 4, 30, 4),
(31, 3, 31, 4),
(32, 2, 32, 4),
(33, 6, 33, 1),
(34, 2, 34, 1),
(35, 1, 34, 1),
(36, 1, 33, 1),
(37, 1, 8, 1),
(38, 9, 9, 2),
(39, 1, 24, 3),
(40, 1, 23, 3),
(41, 1, 22, 3),
(42, 1, 16, 2),
(43, 1, 15, 2),
(44, 1, 13, 2),
(45, 1, 32, 4),
(46, 1, 31, 4),
(47, 1, 30, 4);

-- --------------------------------------------------------

--
-- Table structure for table `table_sy`
--

CREATE TABLE `table_sy` (
  `sy_id` int(11) NOT NULL,
  `start_year` varchar(32) NOT NULL,
  `end_year` varchar(32) NOT NULL,
  `start_month` varchar(11) NOT NULL,
  `end_month` varchar(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_sy`
--

INSERT INTO `table_sy` (`sy_id`, `start_year`, `end_year`, `start_month`, `end_month`, `status`) VALUES
(1, '2015', '2016', '02', '12', 1);

-- --------------------------------------------------------

--
-- Table structure for table `table_teacher`
--

CREATE TABLE `table_teacher` (
  `teacher_id` int(11) NOT NULL,
  `teacher_no` varchar(32) NOT NULL,
  `user_id` int(11) NOT NULL,
  `teacher_mobile` varchar(32) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `middle_name` varchar(32) NOT NULL,
  `city_address` varchar(50) NOT NULL,
  `date_of_birth` varchar(32) NOT NULL,
  `graduate_school` varchar(32) NOT NULL,
  `position_id` int(11) NOT NULL,
  `user_acess` int(11) NOT NULL,
  `added_date` varchar(32) NOT NULL,
  `added_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL,
  `house_no` varchar(40) NOT NULL,
  `street` varchar(40) NOT NULL,
  `barangay` varchar(40) NOT NULL,
  `zip_code` varchar(40) NOT NULL,
  `teacher_email` varchar(100) NOT NULL,
  `department` varchar(20) NOT NULL,
  `gradeLevel` varchar(20) NOT NULL,
  `age` varchar(20) NOT NULL,
  `sex` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_teacher`
--

INSERT INTO `table_teacher` (`teacher_id`, `teacher_no`, `user_id`, `teacher_mobile`, `last_name`, `first_name`, `middle_name`, `city_address`, `date_of_birth`, `graduate_school`, `position_id`, `user_acess`, `added_date`, `added_by`, `updated_date`, `updated_by`, `deleted_date`, `deleted_by`, `house_no`, `street`, `barangay`, `zip_code`, `teacher_email`, `department`, `gradeLevel`, `age`, `sex`) VALUES
(1, '2020-1000', 1, '90556728192', 'Lindo', 'Riley', 'Ashlyn  ', 'Manila', '02/02/1989', '', 0, 0, '', '', '', '', '', '', '18', 'n/a', 'Barangay 21 ', '1012', 'RileyLindo@gmail.com ', '', '', '31', 'Male'),
(2, '2020-1001', 0, '90556728193', 'Abella ', 'Maela  ', 'Diokno  ', 'Manila', '10/02/1989', '', 0, 0, '', '', '', '', '', '', '19', 'n/a', 'Barangay 22 ', '1012', 'Maela  Abella @gmail.com ', '', '', '31', 'Male'),
(3, '2020-1002', 0, '90556728194', 'Inárez', 'Amya', 'Uy', 'Manila', '28/12/1998', '', 0, 0, '', '', '', '', '', '', '20', 'n/a', 'Barangay 22 ', '1012', 'AmyaInárez@gmail.com ', '', '', '21', 'Male'),
(4, '2020-1003', 0, '90556728195', 'Isidro', 'Galenia', 'Alonzo ', 'Mandaluyong', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '21', 'n/a', 'Barangka Ilaya', '1550', 'GaleniaIsidro@gmail.com ', '', '', '20', 'Male'),
(5, '2020-1004', 0, '90556728196', 'Cabrera ', 'Levi', 'Nang  ', 'Taguig', '28/12/1998', '', 0, 0, '', '', '', '', '', '', '22', 'n/a', 'North Daang Hari', '1630', 'LeviCabrera @gmail.com ', '', '', '21', 'Male'),
(6, '2020-1005', 0, '90556728197', 'Baldonado', 'Marissa  ', 'Nallos', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '23', 'n/a', 'Barangay 21 ', '1012', 'MarissaBaldonado@gmail.com ', '', '', '20', 'Female'),
(7, '2020-1006', 0, '90556728198', 'Verano', 'Socorro  ', 'Moya  ', 'Manila', '31/01/1989', '', 0, 0, '', '', '', '', '', '', '24', 'n/a', 'Barangay 22 ', '1012', 'SocorroVerano@gmail.com ', '', '', '31', 'Male'),
(8, '2020-1007', 4, '90556728199', 'Jiménez ', 'Larunda  ', 'Jaiden  ', 'Manila', '03/11/1988', '', 0, 0, '', '', '', '', '', '', '25', 'n/a', 'Barangay 22 ', '1012', 'LarundaJiménez @gmail.com ', '', '', '31', 'Female'),
(9, '2020-1008', 0, '90556728200', 'Atayde', 'Dinora', 'Amani  ', 'Manila', '01/02/1989', '', 0, 0, '', '', '', '', '', '', '26', 'n/a', 'Barangay 21 ', '1012', 'DinoraAtayde@gmail.com ', '', '', '31', 'Male'),
(10, '2020-1009', 0, '90556728201', 'Mineque ', 'Senalda  ', 'Blaine  ', 'Manila', '26/12/1988', '', 0, 0, '', '', '', '', '', '', '27', 'n/a', 'Barangay 22 ', '1012', 'SenaldaMineque @gmail.com ', '', '', '31', 'Female'),
(11, '2020-1010', 0, '90556728202', 'Moreno ', 'Tyler  ', 'Xiomara  ', 'Taguig', '18/06/1993', '', 0, 0, '', '', '', '', '', '', '28', 'n/a', 'North Daang Hari', '1630', 'Tyler  Moreno @gmail.com ', '', '', '27', 'Male'),
(12, '2020-1011', 0, '90556728203', 'Villamar', 'Travon  ', 'India  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '29', 'n/a', 'Barangay 23 ', '1012', 'TravonVillamar@gmail.com ', '', '', '20', 'Male'),
(13, '2020-1012', 0, '90556728204', 'Fontanilla ', 'Daniel', 'Jackson', 'Mandaluyong', '10/07/1965', '', 0, 0, '', '', '', '', '', '', '30', 'n/a', 'Barangka Itaas', '1550', 'DanielFontanilla @gmail.com ', '', '', '54', 'Male'),
(14, '2020-1013', 0, '90556728205', 'Verano ', 'Connor  ', 'Justine  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '31', 'n/a', 'Barangay 22 ', '1012', 'ConnorVerano @gmail.com ', '', '', '20', 'Male'),
(15, '2020-1014', 0, '90556728206', 'España ', 'Zurine  ', 'Quinton  ', 'Taguig', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '32', 'n/a', 'North Daang Hari', '1630', 'Zurine  España @gmail.com ', '', '', '20', 'Male'),
(16, '2020-1015', 0, '90556728207', 'Pastor ', 'Kayley', 'Clark  ', 'Taguig', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '33', 'n/a', 'Western Bicutan', '1630', 'KayleyPastor @gmail.com ', '', '', '20', 'Male'),
(17, '2020-1016', 0, '90556728208', 'Basir', 'Kara  ', 'Montae  ', 'Taguig', '26/12/1988', '', 0, 0, '', '', '', '', '', '', '34', 'n/a', 'Western Bicutan', '1630', 'Kara  Basir@gmail.com ', '', '', '31', 'Male'),
(18, '2020-1017', 0, '90556728209', 'Domingo ', 'Casandra  ', 'Yugi', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '35', 'n/a', 'Barangay 22 ', '1012', 'CasandraDomingo @gmail.com ', '', '', '20', 'Male'),
(19, '2020-1018', 0, '90556728210', 'Ancheta', 'Laurita', 'Miyaki  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '36', 'n/a', 'Barangay 23 ', '1012', 'LauritaAncheta@gmail.com ', '', '', '20', 'Male'),
(20, '2020-1019', 0, '90556728211', 'Ignacio ', 'Alexandra  ', 'Navarro  ', 'Mandaluyong', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '37', 'n/a', 'Barangka Ilaya', '1550', 'Alexandra  Ignacio @gmail.com ', '', '', '20', 'Male'),
(21, '2020-1020', 0, '90556728212', 'Robles', 'Mora', 'Jovan  ', 'Manila', '26/12/1988', '', 0, 0, '', '', '', '', '', '', '38', 'n/a', 'Barangay 23 ', '1012', 'MoraRobles@gmail.com ', '', '', '31', 'Male'),
(22, '2020-1021', 0, '90556728213', 'Jovan  ', 'Adeline  ', 'Kaliyah  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '39', 'n/a', 'Barangay 23 ', '1012', 'Adeline  Jovan  @gmail.com ', '', '', '20', 'Male'),
(23, '2020-1022', 0, '90556728214', 'Esquivias ', 'Penelope  ', 'Magpulong  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '40', 'n/a', 'Barangay 23 ', '1012', 'Penelope  Esquivias @gmail.com ', '', '', '20', 'Male'),
(24, '2020-1023', 0, '90556728215', 'Vizcaya ', 'Jahiem  ', 'Yu', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '41', 'n/a', 'Barangay 22 ', '1012', 'JahiemVizcaya @gmail.com ', '', '', '20', 'Female'),
(25, '2020-1024', 0, '90556728216', 'Vicente', 'Trent', 'Madelyn  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '42', 'n/a', 'Barangay 21 ', '1012', 'TrentVicente@gmail.com ', '', '', '20', 'Male'),
(26, '2020-1025', 0, '90556728217', 'Acebedo ', 'Julianna  ', 'Garbine  ', 'Taguig', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '43', 'n/a', 'Western Bicutan', '1630', 'Julianna  Acebedo @gmail.com ', '', '', '20', 'Male'),
(27, '2020-1026', 0, '90556728218', 'Razón ', 'Simona  ', 'Xzavier', 'Mandaluyong', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '44', 'n/a', 'Barangka Itaas', '1550', 'Simona  Razón @gmail.com ', '', '', '20', 'Male'),
(28, '2020-1027', 0, '90556728219', 'Alba ', 'Jane', 'Cipriano  ', 'Taguig', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '45', 'n/a', 'Western Bicutan', '1630', 'JaneAlba @gmail.com ', '', '', '20', 'Male'),
(29, '2020-1028', 0, '90556728220', 'Acuña', 'Shyanne  ', 'Linganyan  ', 'Manila', '04/06/1990', '', 0, 0, '', '', '', '', '', '', '46', 'n/a', 'Barangay 22 ', '1012', 'Shyanne  Acuña@gmail.com ', '', '', '30', 'Male'),
(30, '2020-1029', 0, '90556728221', 'Alejandro', 'Destinee  ', 'Chionglo  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '47', 'n/a', 'Barangay 22 ', '1012', 'Destinee  Alejandro@gmail.com ', '', '', '20', 'Female'),
(31, '2020-1030', 0, '90556728222', 'Santos ', 'Dania', 'Florencia  ', 'Taguig', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '48', 'n/a', 'Western Bicutan', '1630', 'DaniaSantos @gmail.com ', '', '', '20', 'Male'),
(32, '2020-1031', 0, '90556728223', 'Álvarez ', 'Zachery  ', 'Lucrecia', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '49', 'n/a', 'Barangay 22 ', '1012', 'Zachery  Álvarez @gmail.com ', '', '', '20', 'Male'),
(33, '2020-1032', 3, '90556728224', 'Blanco', 'Aurora  ', 'Yongque  ', 'Manila', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '50', 'n/a', 'Barangay 22 ', '1012', 'Aurora  Blanco@gmail.com ', '', '', '20', 'Male'),
(34, '2020-1033', 2, '90556728225', 'Amparo ', 'Sarai  ', 'Gallano  ', 'Taguig', '01/01/2000', '', 0, 0, '', '', '', '', '', '', '51', 'n/a', 'North Daang Hari', '1630', 'Sarai  Amparo @gmail.com ', '', '', '20', 'Male');

-- --------------------------------------------------------

--
-- Table structure for table `table_time`
--

CREATE TABLE `table_time` (
  `time_id` int(11) NOT NULL,
  `time_name` varchar(32) NOT NULL,
  `level_schedule_id` int(11) NOT NULL,
  `is_recess` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_time`
--

INSERT INTO `table_time` (`time_id`, `time_name`, `level_schedule_id`, `is_recess`) VALUES
(1, '6:20a-7:20a', 1, 0),
(2, '7:20a-8:20a', 1, 0),
(3, '8:20a-9:20a', 1, 0),
(4, '9:20a-9:50a', 1, 1),
(5, '9:50a-10:50a', 1, 0),
(6, '10:50a-11:50a', 1, 0),
(7, '11:50a-12:50p', 1, 0),
(8, '6:20a-7:20a', 3, 0),
(9, '7:20a-8:20a', 3, 0),
(10, '8:20a-9:20a', 3, 0),
(11, '9:20a-10:20a', 3, 0),
(12, '10:20a-10:50a', 3, 1),
(13, '10:50a-11:50a', 3, 0),
(14, '11:50a-12:50a', 3, 0),
(15, '1:00p-2:00p', 2, 0),
(16, '2:00p-3:00p', 2, 0),
(17, '3:00p-3:30p', 2, 1),
(18, '3:30p-4:30p', 2, 0),
(19, '4:30p-5:30p', 2, 0),
(20, '5:30p-6:30p', 2, 0),
(21, '6:30p-7:30p', 2, 0),
(22, '1:00p-2:00p', 4, 0),
(23, '2:00p-3:00p', 4, 0),
(24, '3:00p-4:00p', 4, 0),
(25, '4:00p-4:30p', 4, 1),
(26, '4:30p-5:30p', 4, 0),
(27, '4:30p-5:30p', 4, 0),
(28, '4:30p-5:30p', 4, 0);

-- --------------------------------------------------------

--
-- Table structure for table `table_timesched`
--

CREATE TABLE `table_timesched` (
  `timesched_id` int(11) UNSIGNED NOT NULL,
  `class_id` int(11) NOT NULL,
  `time_id` int(11) NOT NULL,
  `assignment_id` int(11) NOT NULL,
  `day` int(11) NOT NULL,
  `created_date` varchar(32) NOT NULL,
  `created_by` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL,
  `deleted_date` varchar(32) NOT NULL,
  `deleted_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_timesched`
--

INSERT INTO `table_timesched` (`timesched_id`, `class_id`, `time_id`, `assignment_id`, `day`, `created_date`, `created_by`, `updated_date`, `updated_by`, `deleted_date`, `deleted_by`) VALUES
(1, 1, 1, 8, 1, '', '', '', '', '', ''),
(2, 1, 2, 1, 1, '', '', '', '', '', ''),
(3, 1, 3, 2, 1, '', '', '', '', '', ''),
(4, 1, 4, 0, 1, '', '', '', '', '', ''),
(5, 1, 5, 3, 1, '', '', '', '', '', ''),
(6, 1, 6, 4, 1, '', '', '', '', '', ''),
(7, 1, 7, 5, 1, '', '', '', '', '', ''),
(8, 1, 1, 8, 2, '', '', '', '', '', ''),
(9, 1, 2, 1, 2, '', '', '', '', '', ''),
(10, 1, 3, 2, 2, '', '', '', '', '', ''),
(11, 1, 4, 0, 2, '', '', '', '', '', ''),
(12, 1, 5, 3, 2, '', '', '', '', '', ''),
(13, 1, 6, 4, 2, '', '', '', '', '', ''),
(14, 1, 7, 5, 2, '', '', '', '', '', ''),
(15, 1, 1, 8, 3, '', '', '', '', '', ''),
(16, 1, 2, 1, 3, '', '', '', '', '', ''),
(17, 1, 3, 2, 3, '', '', '', '', '', ''),
(18, 1, 4, 0, 3, '', '', '', '', '', ''),
(19, 1, 5, 3, 3, '', '', '', '', '', ''),
(20, 1, 6, 4, 3, '', '', '', '', '', ''),
(21, 1, 7, 5, 3, '', '', '', '', '', ''),
(22, 1, 1, 1, 4, '', '', '', '', '', ''),
(23, 1, 2, 8, 4, '', '', '', '', '', ''),
(24, 1, 3, 2, 4, '', '', '', '', '', ''),
(25, 1, 4, 0, 4, '', '', '', '', '', ''),
(26, 1, 5, 3, 4, '', '', '', '', '', ''),
(27, 1, 6, 4, 4, '', '', '', '', '', ''),
(28, 1, 7, 5, 4, '', '', '', '', '', ''),
(29, 1, 1, 37, 5, '', '', '', '', '', ''),
(30, 1, 2, 7, 5, '', '', '', '', '', ''),
(31, 1, 3, 7, 5, '', '', '', '', '', ''),
(32, 1, 4, 0, 5, '', '', '', '', '', ''),
(33, 1, 5, 7, 5, '', '', '', '', '', ''),
(34, 1, 6, 7, 5, '', '', '', '', '', ''),
(35, 1, 7, 6, 5, '', '', '', '', '', ''),
(36, 2, 1, 34, 1, '', '', '', '', '', ''),
(37, 2, 2, 33, 1, '', '', '', '', '', ''),
(38, 2, 3, 33, 1, '', '', '', '', '', ''),
(39, 2, 4, 0, 1, '', '', '', '', '', ''),
(40, 2, 5, 7, 1, '', '', '', '', '', ''),
(41, 2, 6, 3, 1, '', '', '', '', '', ''),
(42, 2, 7, 1, 1, '', '', '', '', '', ''),
(43, 2, 1, 34, 2, '', '', '', '', '', ''),
(44, 2, 2, 33, 2, '', '', '', '', '', ''),
(45, 2, 3, 33, 2, '', '', '', '', '', ''),
(46, 2, 4, 0, 2, '', '', '', '', '', ''),
(47, 2, 5, 7, 2, '', '', '', '', '', ''),
(48, 2, 6, 3, 2, '', '', '', '', '', ''),
(49, 2, 7, 1, 2, '', '', '', '', '', ''),
(50, 2, 1, 34, 3, '', '', '', '', '', ''),
(51, 2, 2, 5, 3, '', '', '', '', '', ''),
(52, 2, 3, 3, 3, '', '', '', '', '', ''),
(53, 2, 4, 0, 3, '', '', '', '', '', ''),
(54, 2, 5, 35, 3, '', '', '', '', '', ''),
(55, 2, 6, 7, 3, '', '', '', '', '', ''),
(56, 2, 7, 1, 3, '', '', '', '', '', ''),
(57, 2, 1, 34, 4, '', '', '', '', '', ''),
(58, 2, 2, 5, 4, '', '', '', '', '', ''),
(59, 2, 3, 3, 4, '', '', '', '', '', ''),
(60, 2, 4, 0, 4, '', '', '', '', '', ''),
(61, 2, 5, 6, 4, '', '', '', '', '', ''),
(62, 2, 6, 7, 4, '', '', '', '', '', ''),
(63, 2, 7, 1, 4, '', '', '', '', '', ''),
(64, 2, 1, 5, 5, '', '', '', '', '', ''),
(65, 2, 2, 5, 5, '', '', '', '', '', ''),
(66, 2, 3, 2, 5, '', '', '', '', '', ''),
(67, 2, 4, 0, 5, '', '', '', '', '', ''),
(68, 2, 5, 2, 5, '', '', '', '', '', ''),
(69, 2, 6, 2, 5, '', '', '', '', '', ''),
(70, 2, 7, 2, 5, '', '', '', '', '', ''),
(71, 3, 1, 5, 1, '', '', '', '', '', ''),
(72, 3, 2, 7, 1, '', '', '', '', '', ''),
(73, 3, 3, 1, 1, '', '', '', '', '', ''),
(74, 3, 4, 0, 1, '', '', '', '', '', ''),
(75, 3, 5, 33, 1, '', '', '', '', '', ''),
(76, 3, 6, 33, 1, '', '', '', '', '', ''),
(77, 3, 7, 3, 1, '', '', '', '', '', ''),
(78, 3, 1, 5, 2, '', '', '', '', '', ''),
(79, 3, 2, 7, 2, '', '', '', '', '', ''),
(80, 3, 3, 1, 2, '', '', '', '', '', ''),
(81, 3, 4, 0, 2, '', '', '', '', '', ''),
(82, 3, 5, 33, 2, '', '', '', '', '', ''),
(83, 3, 6, 33, 2, '', '', '', '', '', ''),
(84, 3, 7, 3, 2, '', '', '', '', '', ''),
(85, 3, 1, 5, 3, '', '', '', '', '', ''),
(86, 3, 2, 7, 3, '', '', '', '', '', ''),
(87, 3, 3, 1, 3, '', '', '', '', '', ''),
(88, 3, 4, 0, 3, '', '', '', '', '', ''),
(89, 3, 5, 5, 3, '', '', '', '', '', ''),
(90, 3, 6, 3, 3, '', '', '', '', '', ''),
(91, 3, 7, 3, 3, '', '', '', '', '', ''),
(92, 3, 1, 7, 4, '', '', '', '', '', ''),
(93, 3, 2, 2, 4, '', '', '', '', '', ''),
(94, 3, 3, 1, 4, '', '', '', '', '', ''),
(95, 3, 4, 0, 4, '', '', '', '', '', ''),
(96, 3, 5, 2, 4, '', '', '', '', '', ''),
(97, 3, 6, 2, 4, '', '', '', '', '', ''),
(98, 3, 7, 2, 4, '', '', '', '', '', ''),
(99, 3, 1, 6, 5, '', '', '', '', '', ''),
(100, 3, 2, 36, 5, '', '', '', '', '', ''),
(101, 3, 3, 34, 5, '', '', '', '', '', ''),
(102, 3, 4, 0, 5, '', '', '', '', '', ''),
(103, 3, 5, 34, 5, '', '', '', '', '', ''),
(104, 3, 6, 34, 5, '', '', '', '', '', ''),
(105, 3, 7, 34, 5, '', '', '', '', '', ''),
(106, 4, 15, 16, 1, '', '', '', '', '', ''),
(107, 4, 16, 15, 1, '', '', '', '', '', ''),
(108, 4, 17, 0, 1, '', '', '', '', '', ''),
(109, 4, 18, 13, 1, '', '', '', '', '', ''),
(110, 4, 19, 12, 1, '', '', '', '', '', ''),
(111, 4, 20, 11, 1, '', '', '', '', '', ''),
(112, 4, 21, 10, 1, '', '', '', '', '', ''),
(113, 4, 15, 16, 2, '', '', '', '', '', ''),
(114, 4, 16, 15, 2, '', '', '', '', '', ''),
(115, 4, 17, 0, 2, '', '', '', '', '', ''),
(116, 4, 18, 13, 2, '', '', '', '', '', ''),
(117, 4, 19, 12, 2, '', '', '', '', '', ''),
(118, 4, 20, 11, 2, '', '', '', '', '', ''),
(119, 4, 21, 10, 2, '', '', '', '', '', ''),
(120, 4, 15, 16, 3, '', '', '', '', '', ''),
(121, 4, 16, 15, 3, '', '', '', '', '', ''),
(122, 4, 17, 0, 3, '', '', '', '', '', ''),
(123, 4, 18, 13, 3, '', '', '', '', '', ''),
(124, 4, 19, 12, 3, '', '', '', '', '', ''),
(125, 4, 20, 11, 3, '', '', '', '', '', ''),
(126, 4, 21, 10, 3, '', '', '', '', '', ''),
(127, 4, 15, 16, 4, '', '', '', '', '', ''),
(128, 4, 16, 15, 4, '', '', '', '', '', ''),
(129, 4, 17, 0, 4, '', '', '', '', '', ''),
(130, 4, 18, 13, 4, '', '', '', '', '', ''),
(131, 4, 19, 12, 4, '', '', '', '', '', ''),
(132, 4, 20, 11, 4, '', '', '', '', '', ''),
(133, 4, 21, 10, 4, '', '', '', '', '', ''),
(134, 4, 15, 42, 5, '', '', '', '', '', ''),
(135, 4, 16, 38, 5, '', '', '', '', '', ''),
(136, 4, 17, 0, 5, '', '', '', '', '', ''),
(137, 4, 18, 38, 5, '', '', '', '', '', ''),
(138, 4, 19, 38, 5, '', '', '', '', '', ''),
(139, 4, 20, 38, 5, '', '', '', '', '', ''),
(140, 4, 21, 9, 5, '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `table_update_transaction`
--

CREATE TABLE `table_update_transaction` (
  `update_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  `updated_field` varchar(32) NOT NULL,
  `old_data` varchar(32) NOT NULL,
  `new_data` varchar(32) NOT NULL,
  `updated_date` varchar(32) NOT NULL,
  `updated_by` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `table_users`
--

CREATE TABLE `table_users` (
  `user_id` int(10) UNSIGNED NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `access_id` int(20) NOT NULL,
  `position_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_users`
--

INSERT INTO `table_users` (`user_id`, `username`, `password`, `access_id`, `position_id`) VALUES
(1, '2020-1000', 'jKT3uJ+I8v4JdpIhSrZbrmt8Ry+gKpmdI+xrYUiZhXHBIwJ0', 1, 1),
(2, '2020-1033', '2ASEZiuSWoRFeNqZQSGVekk/Ukv3luVQu/6MEsRLtDXF788p', 2, 3),
(3, '2020-1032', 'L+KQtvOIgmpXRnoZJ+1oC1eCJpw1p5nwnnfHHxH0tVPfc32F', 2, 3),
(4, '2020-1007', 'coflrQlN1kYsmtWS+6WwY5eUggmMNQ8Jgkww56/zwsvPm4+X', 2, 3);

-- --------------------------------------------------------

--
-- Table structure for table `table_user_access`
--

CREATE TABLE `table_user_access` (
  `access_id` int(11) NOT NULL,
  `role` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_user_access`
--

INSERT INTO `table_user_access` (`access_id`, `role`) VALUES
(1, 'Admin'),
(2, 'User');

-- --------------------------------------------------------

--
-- Table structure for table `table_zip_code`
--

CREATE TABLE `table_zip_code` (
  `zip_id` int(11) NOT NULL,
  `zip_code` int(11) NOT NULL,
  `city_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `table_zip_code`
--

INSERT INTO `table_zip_code` (`zip_id`, `zip_code`, `city_id`) VALUES
(1, 1006, 1),
(2, 1002, 1),
(3, 1004, 1),
(4, 1007, 1),
(5, 1011, 1),
(6, 1018, 1),
(7, 1001, 1),
(8, 1008, 1),
(9, 1015, 1),
(10, 1017, 1),
(11, 1005, 1),
(12, 1010, 1),
(13, 1009, 1),
(14, 1014, 1),
(15, 1003, 1),
(16, 1016, 1),
(17, 1013, 1),
(18, 1012, 1),
(19, 1554, 2),
(20, 1556, 2),
(21, 1550, 2),
(22, 1553, 2),
(23, 1552, 2),
(24, 1551, 2),
(25, 1555, 2),
(26, 1000, 1),
(27, 1636, 3),
(28, 1631, 3),
(29, 1632, 3),
(30, 1633, 3),
(31, 1630, 3),
(32, 1638, 3),
(33, 1634, 3),
(34, 1637, 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `archive_class`
--
ALTER TABLE `archive_class`
  ADD PRIMARY KEY (`archive_class_id`);

--
-- Indexes for table `archive_delete_transaction`
--
ALTER TABLE `archive_delete_transaction`
  ADD PRIMARY KEY (`archived_delete_id`);

--
-- Indexes for table `archive_grading`
--
ALTER TABLE `archive_grading`
  ADD PRIMARY KEY (`archive_grading_id`);

--
-- Indexes for table `archive_graduated_students`
--
ALTER TABLE `archive_graduated_students`
  ADD PRIMARY KEY (`archive_graduated__id`);

--
-- Indexes for table `archive_guardian_info`
--
ALTER TABLE `archive_guardian_info`
  ADD PRIMARY KEY (`guardian_id`);

--
-- Indexes for table `archive_schedule`
--
ALTER TABLE `archive_schedule`
  ADD PRIMARY KEY (`archive_schedule_id`);

--
-- Indexes for table `archive_school_history`
--
ALTER TABLE `archive_school_history`
  ADD PRIMARY KEY (`history`);

--
-- Indexes for table `archive_update_transaction`
--
ALTER TABLE `archive_update_transaction`
  ADD PRIMARY KEY (`archive_update_id`);

--
-- Indexes for table `table_barangay`
--
ALTER TABLE `table_barangay`
  ADD PRIMARY KEY (`barangay_id`);

--
-- Indexes for table `table_city`
--
ALTER TABLE `table_city`
  ADD PRIMARY KEY (`city_id`);

--
-- Indexes for table `table_class`
--
ALTER TABLE `table_class`
  ADD PRIMARY KEY (`class_id`);

--
-- Indexes for table `table_delete_transaction`
--
ALTER TABLE `table_delete_transaction`
  ADD PRIMARY KEY (`delete_id`);

--
-- Indexes for table `table_department`
--
ALTER TABLE `table_department`
  ADD PRIMARY KEY (`department_id`);

--
-- Indexes for table `table_enrollment`
--
ALTER TABLE `table_enrollment`
  ADD PRIMARY KEY (`enrollment_no`);

--
-- Indexes for table `table_enrollment_period`
--
ALTER TABLE `table_enrollment_period`
  ADD PRIMARY KEY (`enrollment_period_id`);

--
-- Indexes for table `table_enrollment_settings`
--
ALTER TABLE `table_enrollment_settings`
  ADD PRIMARY KEY (`enrollment_settings_id`);

--
-- Indexes for table `table_events`
--
ALTER TABLE `table_events`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `table_file_status`
--
ALTER TABLE `table_file_status`
  ADD PRIMARY KEY (`status_id`);

--
-- Indexes for table `table_grades`
--
ALTER TABLE `table_grades`
  ADD PRIMARY KEY (`grade_id`);

--
-- Indexes for table `table_grade_encoding`
--
ALTER TABLE `table_grade_encoding`
  ADD PRIMARY KEY (`encoding_id`);

--
-- Indexes for table `table_grade_level`
--
ALTER TABLE `table_grade_level`
  ADD PRIMARY KEY (`grade_level_id`);

--
-- Indexes for table `table_grading_period`
--
ALTER TABLE `table_grading_period`
  ADD PRIMARY KEY (`grading_period_id`);

--
-- Indexes for table `table_guardian`
--
ALTER TABLE `table_guardian`
  ADD PRIMARY KEY (`guardian_id`);

--
-- Indexes for table `table_guardian_relationship`
--
ALTER TABLE `table_guardian_relationship`
  ADD PRIMARY KEY (`relationship_id`);

--
-- Indexes for table `table_level_schedule`
--
ALTER TABLE `table_level_schedule`
  ADD PRIMARY KEY (`level_schedule_id`);

--
-- Indexes for table `table_level_section`
--
ALTER TABLE `table_level_section`
  ADD PRIMARY KEY (`level_section_id`);

--
-- Indexes for table `table_module`
--
ALTER TABLE `table_module`
  ADD PRIMARY KEY (`module_id`);

--
-- Indexes for table `table_position`
--
ALTER TABLE `table_position`
  ADD PRIMARY KEY (`position_id`);

--
-- Indexes for table `table_room`
--
ALTER TABLE `table_room`
  ADD PRIMARY KEY (`room_id`);

--
-- Indexes for table `table_school_history`
--
ALTER TABLE `table_school_history`
  ADD PRIMARY KEY (`history_id`);

--
-- Indexes for table `table_settings`
--
ALTER TABLE `table_settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `table_students`
--
ALTER TABLE `table_students`
  ADD PRIMARY KEY (`student_id`);

--
-- Indexes for table `table_student_status`
--
ALTER TABLE `table_student_status`
  ADD PRIMARY KEY (`status_id`);

--
-- Indexes for table `table_subject`
--
ALTER TABLE `table_subject`
  ADD PRIMARY KEY (`subject_id`);

--
-- Indexes for table `table_subject_assignment`
--
ALTER TABLE `table_subject_assignment`
  ADD PRIMARY KEY (`assignment_id`);

--
-- Indexes for table `table_sy`
--
ALTER TABLE `table_sy`
  ADD PRIMARY KEY (`sy_id`);

--
-- Indexes for table `table_teacher`
--
ALTER TABLE `table_teacher`
  ADD PRIMARY KEY (`teacher_id`);

--
-- Indexes for table `table_time`
--
ALTER TABLE `table_time`
  ADD PRIMARY KEY (`time_id`);

--
-- Indexes for table `table_timesched`
--
ALTER TABLE `table_timesched`
  ADD PRIMARY KEY (`timesched_id`);

--
-- Indexes for table `table_update_transaction`
--
ALTER TABLE `table_update_transaction`
  ADD PRIMARY KEY (`update_id`);

--
-- Indexes for table `table_users`
--
ALTER TABLE `table_users`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `table_user_access`
--
ALTER TABLE `table_user_access`
  ADD PRIMARY KEY (`access_id`);

--
-- Indexes for table `table_zip_code`
--
ALTER TABLE `table_zip_code`
  ADD PRIMARY KEY (`zip_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `archive_class`
--
ALTER TABLE `archive_class`
  MODIFY `archive_class_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_delete_transaction`
--
ALTER TABLE `archive_delete_transaction`
  MODIFY `archived_delete_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_grading`
--
ALTER TABLE `archive_grading`
  MODIFY `archive_grading_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_graduated_students`
--
ALTER TABLE `archive_graduated_students`
  MODIFY `archive_graduated__id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_guardian_info`
--
ALTER TABLE `archive_guardian_info`
  MODIFY `guardian_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_schedule`
--
ALTER TABLE `archive_schedule`
  MODIFY `archive_schedule_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_school_history`
--
ALTER TABLE `archive_school_history`
  MODIFY `history` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `archive_update_transaction`
--
ALTER TABLE `archive_update_transaction`
  MODIFY `archive_update_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `table_barangay`
--
ALTER TABLE `table_barangay`
  MODIFY `barangay_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=975;

--
-- AUTO_INCREMENT for table `table_city`
--
ALTER TABLE `table_city`
  MODIFY `city_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `table_class`
--
ALTER TABLE `table_class`
  MODIFY `class_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `table_delete_transaction`
--
ALTER TABLE `table_delete_transaction`
  MODIFY `delete_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `table_department`
--
ALTER TABLE `table_department`
  MODIFY `department_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `table_enrollment`
--
ALTER TABLE `table_enrollment`
  MODIFY `enrollment_no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `table_enrollment_settings`
--
ALTER TABLE `table_enrollment_settings`
  MODIFY `enrollment_settings_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `table_events`
--
ALTER TABLE `table_events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `table_file_status`
--
ALTER TABLE `table_file_status`
  MODIFY `status_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `table_grades`
--
ALTER TABLE `table_grades`
  MODIFY `grade_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1409;

--
-- AUTO_INCREMENT for table `table_grade_encoding`
--
ALTER TABLE `table_grade_encoding`
  MODIFY `encoding_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `table_grade_level`
--
ALTER TABLE `table_grade_level`
  MODIFY `grade_level_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `table_grading_period`
--
ALTER TABLE `table_grading_period`
  MODIFY `grading_period_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `table_guardian`
--
ALTER TABLE `table_guardian`
  MODIFY `guardian_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `table_guardian_relationship`
--
ALTER TABLE `table_guardian_relationship`
  MODIFY `relationship_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `table_level_section`
--
ALTER TABLE `table_level_section`
  MODIFY `level_section_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `table_module`
--
ALTER TABLE `table_module`
  MODIFY `module_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `table_position`
--
ALTER TABLE `table_position`
  MODIFY `position_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `table_room`
--
ALTER TABLE `table_room`
  MODIFY `room_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `table_school_history`
--
ALTER TABLE `table_school_history`
  MODIFY `history_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `table_settings`
--
ALTER TABLE `table_settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `table_students`
--
ALTER TABLE `table_students`
  MODIFY `student_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `table_student_status`
--
ALTER TABLE `table_student_status`
  MODIFY `status_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `table_subject`
--
ALTER TABLE `table_subject`
  MODIFY `subject_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `table_subject_assignment`
--
ALTER TABLE `table_subject_assignment`
  MODIFY `assignment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT for table `table_sy`
--
ALTER TABLE `table_sy`
  MODIFY `sy_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `table_teacher`
--
ALTER TABLE `table_teacher`
  MODIFY `teacher_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `table_time`
--
ALTER TABLE `table_time`
  MODIFY `time_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `table_timesched`
--
ALTER TABLE `table_timesched`
  MODIFY `timesched_id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=141;

--
-- AUTO_INCREMENT for table `table_update_transaction`
--
ALTER TABLE `table_update_transaction`
  MODIFY `update_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `table_users`
--
ALTER TABLE `table_users`
  MODIFY `user_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `table_user_access`
--
ALTER TABLE `table_user_access`
  MODIFY `access_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `table_zip_code`
--
ALTER TABLE `table_zip_code`
  MODIFY `zip_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
